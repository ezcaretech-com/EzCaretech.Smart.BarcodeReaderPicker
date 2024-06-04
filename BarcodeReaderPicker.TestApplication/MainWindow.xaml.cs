using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BarcodeReaderPicker.TestApplication
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadPlugins();
            LoadDefaults();
        }

        private void LoadPlugins()
        {
            try
            {
                Loader loader = new Loader();
                loader.LoadPluginAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", ex.Message));
                Environment.Exit(0);
            }
        }

        private void LoadDefaults()
        {
            List<string> barcodeTypes = new List<string>();

            foreach (EncodingFormat type in Enum.GetValues(typeof(EncodingFormat)))
            {
                barcodeTypes.Add(type.ToString());
            }

            BarcodeTypeCbo.ItemsSource = barcodeTypes;
            BarcodeTypeCbo.SelectedIndex = 0;
        }

        private string OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png, *.tif)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.tif";
            fileDialog.Multiselect = false;

            bool isSelected = fileDialog.ShowDialog() ?? false;

            return isSelected ? fileDialog.FileNames[0] : null;
        }

        private void SetResults(string[] results)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string result in results)
            {
                sb.AppendLine(result);
            }

            BarcodeData.Text = sb.ToString();
        }

        private void BarcodeReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                if (sender is Button button)
                {
                    Configuration config = new Configuration
                    {
                        License = LicenseText.Text,
                        Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                    };

                    IBarcodeReaderPlugin plugin = Loader.GetPlugin(button.Tag.ToString(), config);

                    string[] results = plugin.Execute(imageFilePath);

                    BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                    SetResults(results);
                }
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }
    }
}
