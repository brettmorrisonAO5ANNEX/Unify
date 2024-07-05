using Microsoft.Win32;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unify.classes;

namespace Unify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private string _filePath { get; set; }
        private Mat _input {  get; set; }
        private Mat _output { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseFiles(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            _filePath = (bool)result ? dialog.FileName : null;

            if (_filePath != null)
            {
                FilePath.Text = System.IO.Path.GetFileName(_filePath);
                _input = Cv2.ImRead(_filePath);
            }
        }

        private void RunApp(object sender, RoutedEventArgs e)
        {
            //test
            if (_input != null)
            {
                _output = BasicProcessing.ApplyBasicFilter(BasicFilter.Pixelate, _input, new object[] { 40, _input.Width, _input.Height });
                DisplayResults();
            }
        }

        private void DisplayResults()
        {
            InputImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(_input);
            OutputImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(_output);
        }

        private void SaveImage(Mat img)
        {
            string savePath;
            var dialog = new SaveFileDialog();
            bool? result = dialog.ShowDialog();
            savePath = (bool)result ? dialog.FileName : null;

            //save the image
            if (savePath != null)
            {
                Cv2.ImWrite(savePath, img);
            }
        }
    }
}
