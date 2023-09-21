using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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

        private void EzBarcodeReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("EzBarcodeReader", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void BarcodeLibReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("BarcodeLibReader", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void Dynamsoft5ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("DynamsoftBarcodeReader5", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void Dynamsoft6ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("DynamsoftBarcodeReader6", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void Dynamsoft7ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("DynamsoftBarcodeReader7", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void IronBarcodeReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("IronBarcodeReader", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }

        private void ZXingBarcodeReadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageFilePath = OpenFile();

                if (string.IsNullOrEmpty(imageFilePath))
                    return;

                Configuration config = new Configuration
                {
                    License = LicenseText.Text,
                    Format = (EncodingFormat)Enum.Parse(typeof(EncodingFormat), BarcodeTypeCbo.SelectedValue.ToString()),
                };

                IPlugin plugin = Loader.GetPlugin("ZXingBarcodeReader", config);

                string[] results = plugin.Execute(imageFilePath);

                BarcodeImage.Source = new BitmapImage(new Uri(imageFilePath));

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults(new string[] { $"Caught exception: {ex.Message}" });
            }
        }
    }
}
