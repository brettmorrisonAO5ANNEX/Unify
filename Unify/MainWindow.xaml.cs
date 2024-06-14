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

        /* TODO: create wallpaper maker tab
         * - for this PC (fetch dimensions)
         * - for another PC (input dimensions)
         * - choose filter
         */
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
                var img_result = BasicProcessing.Pixelate(img, 8, new OpenCvSharp.Size(1920, 1200));
                SaveImage(img_result);
            }
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
