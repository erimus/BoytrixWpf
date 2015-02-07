using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Media.Imaging;
using Boytrix.Data.DAL.DataAccess;
using Boytrix.Logic.DataTransfer.Model;


namespace ImageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SaveImage : ISaveImage
    {

        public void Save(string fileName, Image img, string module,string uploadID)
        {
            string destDirectory = ServerDataFilePath.ImagesPath + @"\" + module + @"\" + uploadID;
            if (!Directory.Exists(destDirectory))
                Directory.CreateDirectory(destDirectory);


             var dal = new ImageDal();
            dal.SaveJpeg(destDirectory + @"\" + fileName, img, 50);
           
        }


        public Stream FetchImage(string imageName)
        {
            string filePath = @"c:\\" + imageName;
            if (File.Exists(filePath))
            {
                FileStream fs = File.OpenRead(filePath);
                WebOperationContext.Current.OutgoingRequest.ContentType = "image/jpeg";
                return fs;
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(" Requested Image does not exist :(");
            MemoryStream strm = new MemoryStream(byteArray);
            return strm;
        }

        public List<ImageDetails> FetchImages(string directory)
        {
            string root = directory;
            string[] supportedExtensions = { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
            var files = Directory.GetFiles(Path.Combine(root, "Images"), "*.*").Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));

            List<ImageDetails> images = new List<ImageDetails>();

            foreach (var file in files)
            {
                ImageDetails id = new ImageDetails
                {
                    Path = file,
                    FileName = Path.GetFileName(file),
                    Extension = Path.GetExtension(file)
                };

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.UriSource = new Uri(file, UriKind.Absolute);
                img.EndInit();
                id.Width = img.PixelWidth;
                id.Height = img.PixelHeight;

                // I couldn't find file size in BitmapImage
                FileInfo fi = new FileInfo(file);
                id.Size = fi.Length;
                images.Add(id);
            }

            return images;
        }

    }
   
    public class ServerDataFilePath
    {
        public static string ImagesPath { get { return ConfigurationManager.ConnectionStrings["ImagesPath"].ConnectionString; } }
    }



}




