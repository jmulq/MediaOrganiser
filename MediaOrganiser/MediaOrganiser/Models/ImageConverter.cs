using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class ImageConverter
    {
        public static byte[] ImageToByteArray(string path)
        {
            byte[] byteData = System.IO.File.ReadAllBytes(path);
            return byteData;
        }
        //public static  ImageToThumbnail
    }
}
