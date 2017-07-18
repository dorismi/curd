using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CustomersOrdersOrderDetailsViewModel
    {
        //public Customers CustomerData { set; get; }
        //public IEnumerable<Orders> OrderCollection { set; get; }
        //public IEnumerable<Order_Details> OrderDetailCollection { set; get; }

        public string CompanyName { set; get; }
        public int OrderYear { set; get; }
        public decimal Amount { set; get; }
    }
}