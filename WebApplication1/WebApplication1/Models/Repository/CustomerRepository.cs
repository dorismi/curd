using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        protected NorthwindEntities db
        {
            get;
            private set;
        }

        public CustomerRepository()
        {
            this.db = new NorthwindEntities();
        }

        public void Create(Customers instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Customers.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Customers instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(Customers instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public Customers Get(string CustomerID)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerID == CustomerID);
        }

        public IQueryable<Customers> GetAll()
        {
            return db.Customers.OrderBy(x => x.CustomerID);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}