using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface ICustomerRepository
    {
        void Create(Customers instance);

        void Update(Customers instance);

        void Delete(Customers instance);

        Customers Get(string CustomerID);

        IQueryable<Customers> GetAll();

        void SaveChanges();
    }
}