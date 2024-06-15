using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Unify.classes;

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
        /// applies the given filter to the image and returns the result
        /// </summary>
        /// <param name="filter">the filter to be applied</param>
        /// <param name="img">the image to process</param>
        /// <param name="args">all additional parameters for the filter in order (to be parsed in the filter func)</param>
        /// <returns></returns>
        public static Mat ApplyBasicFilter(Func<Mat, String[], Mat> filter, Mat img, string[] args=null)
        {
            return filter(img, args);
        }
    }
}
