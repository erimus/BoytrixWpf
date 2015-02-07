using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Boytrix.Data.DAL.DataAccess
{
    //class ImageDal
    //{
    //}

     //string path, System.Drawing.Imaging.ImageCodecInfo jpegCodec, System.Drawing.Imaging.EncoderParameters encoderParams, 

    public class ImageDal
    {
        public  void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("Quality must be between 0 and 100.");

            EncoderParameter qualityParam =
                new EncoderParameter(Encoder.Quality, quality);

            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }



        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {

            //create an array of ImageCodecInfo by using GetImageEncoders()

            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            //first loop through all the encoders that were returned from our ImageCodecInfo array

            for (int i = 0; i < encoders.Length; ++i)
            {
                //now we need to check for a match to the mime type we're providing

                //otherwise we return null

                if (encoders[i].MimeType.ToLower() == mimeType.ToLower())

                    return encoders[i];
            }
            return null;

        }
    }
}
