using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ImageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISaveImage
    {
          [OperationContract]
        void Save(string fileName, Image img, string module, string uploadID);
          [OperationContract]
          [WebGet]
          Stream FetchImage(string imageName);

    }
}
