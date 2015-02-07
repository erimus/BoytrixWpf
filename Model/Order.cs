using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Boytrix.Logic.Business.Common;
using Microsoft.Build.Framework;

namespace Boytrix.Logic.DataTransfer.Model
{
    //[XmlRoot]
    [DataContract]
    public class ShippingMethods : ObservableCollection<ShippingMethod>
    {
        ///// <summary>
        ///// Gets or sets SystemUsersList.
        ///// </summary>
        ////[XmlElement(ElementName = "ShippingMethod")]
        //[DataMember]
        //public List<ShippingMethod> ShippingMethodList { get; set; }
        //[DataMember]
        //public ShippingMethod ShippingMethodItem { get; set; }
    }

    [Serializable, XmlRoot("ShippingMethod")]
    [DataContract]
    public class ShippingMethod : ModelValidationBase
    {
        [Required]
        [DataMember]      
        public string ShippingMethodName { get; set; }
        [Required]
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        [DoNotIncludeField]
        public DateTime DateCreated { get; set; }
         [DoNotIncludeField]
        bool IsActive { get; set; }
    }


    public class Order
    {
        public String CustomerId { get; set; }
        public String OrderNumber { get; set; }
        public int StoreId { get; set; }
        public Decimal OrderWeight { get; set; }
        public String OrderNotes { get; set; }
        public String PoNumber { get; set; }
        public DateTime ShippedOn { get; set; }
        public String CustomerServiceNotes { get; set; }
        public String ShippingInstruction { get; set; }
        public String ShippingTrackingNumber { get; set; }
        public String ShippingMethod { get; set; }
        public Decimal ShippingTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxTotal { get; set; }
        public Decimal DiscountTotal { get; set; }
        public DateTime ExpectedStockArivalDate { get; set; }
        public String OrderWarehouse { get; set; }
        public bool OrderShipmentLoaded { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String ShippingName { get; set; }
        public String ShippingAttentionTo { get; set; }
        public String EMail { get; set; }
        public String OriginalWarehouseId { get; set; }
        public String Currency { get; set; }
        public String PaymentStatus { get; set; }
        public String SmsPhoneNumber { get; set; }
        public String SiteID { get; set; }
        public DateTime CustomerExpectedDate { get; set; }
        public long HybrisProcessId { get; set; }
        public String CollectionPup { get; set; }

        [XmlIgnore()]
        public bool IsArchived { get; protected set; }
        public bool IsAnimalsLoaded { get; set; }

        public String OrderStatus { get; set; }
    }
}
