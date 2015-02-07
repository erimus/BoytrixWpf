using System;

namespace Boytrix.Logic.Business.Common.SearchState
{
    public enum OrderScreenFilter
    {
        ByOrderID = 1,
        ByCustomerID = 2,
        ByOrderDate = 3,
        ByCustomerEmail = 4,
        ByShippingPostCode = 5,
        ByBillingPostCode = 6,
        BySKU = 7,
        ByProductName = 8,
        ByMainStoreSKU = 9,
        ByImportDate = 10,
        ByExportDate = 11,
        ByShippingMethod = 12
    }

    //public enum OrderScreenDateFilter
    //{
    //    Equals = 1,
    //    Before = 2,
    //    After = 3,
    //    Between = 4
    //}
    public class OrderScreenDateFilter
    {
        public OrderScreenDateFilter(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
   public  class OrderSearchService
    {
        public  byte? AllocatedOrders { get; set; } // Y for allocated ; N for nonallocated; Empty for both
        public byte? ExportedOrders { get; set; } // Y for exported ; N for nonexported; Empty for both
        public byte? FilterBy { get; set; }

       
        public  String WarehouseID { get; set; }
        public  String SKU { get; set; }
        public  byte?  AllocatedProduct { get; set; }
       // public  OrderScreenFilter FilterBy { get; set; }
        public  String FilterValue { get; set; }
        public  byte?  FilterDateBy { get; set; }
        public  DateTime FilterDateFrom { get; set; }
        public  DateTime FilterDateTo { get; set; }
        public  bool GetShipmentOnly { get; set; }
        public String ShippingMethod { get; set; }
        //@Allocated bit,@Exported bit,@FilterBy int,@FilterByValue nvarchar(255), @ItemAllocated bit, @FilterByDate int, @FilterDateFrom datetime, @FilterDateTo datetime
        //string StrAllocatedChk { get; set; }
        //string StrExportedChk { get; set; }
        //string StrFilterBy { get; set; }
        //string StrFilterByValue { get; set; }
        //string StrItemAllocatedChk { get; set; }
        //string StrFilterByDate { get; set; }
        //string StrFilterDateFrom { get; set; }
        //string StrFilterDateTo { get; set; }
    }
}
