using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify.classes
{
    /// <summary>
    /// holds all basic image filters
    /// 
    /// BASIC FILTER FORMAT (order and type of args): 
    /// 1. Mat input
    /// 2. List<object> all additional args in order (to be parsed)
    /// returns a Mat
    /// 
    /// </summary>
    public class BasicFilter
    {
        /// <summary>
        /// pixelates an image by downsizing and resizing w/ nearest neighbour interpolation to a specified size
        /// </summary>
        /// <param name="input">image to process</param>
        /// <param name="args">
        /// 1. donwsizing factor 
        /// 2. output width
        /// 3. output height
        /// </param>
        /// <returns>a pixelated version of the input image</returns>
        //public static Mat Pixelate(Mat input, int pixel_size, OpenCvSharp.Size output_dimensions)
        public static Mat Pixelate(Mat input, List<object> args)
        {
            //parse args
            int pixel_size = (int)args[0];
            Size output_dimensions = new Size((int)args[1], (int)args[2]);

            //apply filter
            var dimensions = input.Size();
            var downsized_img = new Mat();
            Cv2.Resize(input, downsized_img, new OpenCvSharp.Size(dimensions.Width / pixel_size, dimensions.Height / pixel_size), interpolation: InterpolationFlags.Nearest);
            var pixelated_img = new Mat();
            Cv2.Resize(downsized_img, pixelated_img, output_dimensions, interpolation: InterpolationFlags.Nearest);
            return pixelated_img;
        }
    }
}
