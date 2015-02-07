
//using Boytrix.Logic.Model.Validation;
//using System;
//using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Serialization;
//using System.Xml.Serialization;
//namespace Boytrix.Logic.Model.Classes.BoytrixData
//{
//    //[XmlRoot]
//    [DataContract]
//    public class ShippingMethods : ObservableCollection<ShippingMethod>
//    {
//        ///// <summary>
//        ///// Gets or sets SystemUsersList.
//        ///// </summary>
//        ////[XmlElement(ElementName = "ShippingMethod")]
//        //[DataMember]
//        //public List<ShippingMethod> ShippingMethodList { get; set; }
//        //[DataMember]
//        //public ShippingMethod ShippingMethodItem { get; set; }
//    }

//    [Serializable, XmlRoot("ShippingMethod")]
//    [DataContract]
//    public class ShippingMethod : ModelValidationBase
//    {
//        [Required]
//        [DataMember]      
//        public string ShippingMethodName { get; set; }
//        [Required]
//        [DataMember]
//        public int Priority { get; set; }
//        [DataMember]
//        [DoNotIncludeField]
//        public DateTime DateCreated { get; set; }
//         [DoNotIncludeField]
//        bool IsActive { get; set; }
//    }
//}
