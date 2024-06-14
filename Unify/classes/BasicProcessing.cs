using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Unify
{
    /// <summary>
    /// a class containing various methods for basic image procesing
    /// -> by basic I mean tasks that involve simple filtering, adjustments, etc
    ///    no complex analysis
    /// </summary>
    public class BasicProcessing
    {
        /// <summary>
        /// pixelates an image by downsizing and resizing w/ nearest neighbour interpolation to a specified size
        /// </summary>
        /// <param name="input">image to process</param>
        /// <param name="pixel_size">downsizing factor - determines the resulting pizelated size</param>
        /// <param name="output_dimensions">the dimensions to size up to</param>
        /// <returns>a pixelated version of the input image</returns>
        public static Mat Pixelate(Mat input, int pixel_size, OpenCvSharp.Size output_dimensions)
        {
            var dimensions = input.Size();
            var downsized_img = new Mat();
            Cv2.Resize(input, downsized_img, new OpenCvSharp.Size(dimensions.Width / pixel_size, dimensions.Height / pixel_size), interpolation: InterpolationFlags.Nearest);
            var pixelated_img = new Mat();
            Cv2.Resize(downsized_img, pixelated_img, output_dimensions, interpolation: InterpolationFlags.Nearest);
            return pixelated_img;
        }

    }
}
