using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface IOrderRepository
    {
        void Create(Orders instance);

        void Update(Orders instance);

        void Delete(Orders instance);

        Orders Get(int productID);

        IQueryable<Orders> GetAll();

        void SaveChanges();
    }
}