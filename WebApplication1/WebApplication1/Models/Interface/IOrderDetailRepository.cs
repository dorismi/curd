using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.ViewModels;

namespace WebApplication1.Models.Interface
{
    public interface IOrderDetailRepository
    {
        void Create(Order_Details instance);

        void Update(Order_Details instance);

        void Delete(Order_Details instance);

        Order_Details Get(int OrderID);

        IQueryable<OrderOrderDetailViewModel> GetOrderDetailnProduct(int OrderID);

        IQueryable<Order_Details> GetAll();

        void SaveChanges();
    }
}