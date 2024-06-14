using Microsoft.Win32;
using OpenCvSharp;
using System;
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

namespace Unify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            //load image
            string filePath;
            var dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            filePath = (bool)result ? dialog.FileName : null;

            //process and save image
            if (filePath != null)
            {
                var img = Cv2.ImRead(filePath);
                var img_result = Pixelate(img, 8);
                SaveImage(img_result);
            }
        }

        private Mat Pixelate(Mat input, int pixel_size)
        {
            var dimensions = input.Size();
            var downsized_img = new Mat();
            Cv2.Resize(input, downsized_img, new OpenCvSharp.Size(dimensions.Width / pixel_size, dimensions.Height / pixel_size), interpolation:InterpolationFlags.Nearest);
            var pixelated_img = new Mat();
            Cv2.Resize(downsized_img, pixelated_img, new OpenCvSharp.Size(1920, 1200), interpolation: InterpolationFlags.Nearest);
            return pixelated_img;
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
