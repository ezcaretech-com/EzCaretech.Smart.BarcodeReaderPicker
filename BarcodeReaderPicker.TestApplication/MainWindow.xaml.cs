using Microsoft.Win32;
using System;
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
        }

        private void LoadPlugins()
        {
            try
            {
                BarcodeReaderLoader loader = new BarcodeReaderLoader();
                loader.LoadPlugins(".");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", ex.Message));
                Environment.Exit(0);
            }
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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("EzBarcodeReader");

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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("BarcodeLibReader");

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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("DynamsoftBarcodeReader5", LicenseText.Text);

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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("DynamsoftBarcodeReader6", LicenseText.Text);

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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("DynamsoftBarcodeReader7", LicenseText.Text);

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

                IBarcodeReaderPlugin plugin = BarcodeReaderLoader.GetPlugin("IronBarcodeReader", LicenseText.Text);

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
