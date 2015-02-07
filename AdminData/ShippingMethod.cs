//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Runtime.Serialization;
//using System.Xml.Serialization;

//namespace Boytrix.Logic.Model.Classes.AdminData
//{
//    //[XmlRoot]
//    [DataContract]
//    public class ShippingMethods : ObservableCollection<ShippingMethod>
//    {
//        /// <summary>
//        /// Gets or sets SystemUsersList.
//        /// </summary>
//        //[XmlElement(ElementName = "ShippingMethod")]
//        [DataMember]
//        public List<ShippingMethod> ShippingMethodList { get; set; }
//        [DataMember]
//        public ShippingMethod ShippingMethodItem { get; set; }
//    }

//    [Serializable, XmlRoot("ShippingMethod")]
//    [DataContract]
//    public class ShippingMethod
//    {
//        [DataMember]
//        public string ShippingMethodName { get; set; }
//        [DataMember]
//        public int Priority { get; set; }
//        [DataMember]
//        public DateTime DateCreated { get; set; }
//    }
//}
