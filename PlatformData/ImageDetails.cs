namespace PlatformData
{
    public class ImageDetails
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Path { get; set; } 
        public string FileName { get; set; } 
        /// <summary> /// The file name extension: bmp, gif, jpg, png, tiff, etc... /// </summary> 
        public string Extension { get; set; } 
        public int Height { get; set; } 
        public int Width { get; set; } 
        /// <summary> /// The file size of the image. /// </summary> 
        public long Size { get; set; } 
    } 

}
