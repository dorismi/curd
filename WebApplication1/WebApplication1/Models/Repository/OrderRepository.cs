using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        protected NorthwindEntities db
        {
            get;
            private set;
        }

        public OrderRepository()
        {
            this.db = new NorthwindEntities();
        }

        public void Create(Orders instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Orders.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Orders instance)
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

        public void Delete(Orders instance)
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

        public Orders Get(int OrderID)
        {
            return db.Orders.FirstOrDefault(x => x.OrderID == OrderID);
        }

        public IQueryable<Orders> GetAll()
        {
            return db.Orders.OrderBy(x => x.OrderID);
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