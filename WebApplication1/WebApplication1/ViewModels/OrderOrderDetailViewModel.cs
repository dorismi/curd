using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OrderOrderDetailViewModel
    {
        public int OrderId { set; get; }
        public decimal UnitPrice { set; get; }
        public int Quantity { set; get; }
        public string ProductName { set; get; }
    }
}