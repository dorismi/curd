using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository, IDisposable
    {
        protected NorthwindEntities db
        {
            get;
            private set;
        }

        public OrderDetailRepository()
        {
            this.db = new NorthwindEntities();
        }

        public void Create(Order_Details instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Order_Details.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Order_Details instance)
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

        public void Delete(Order_Details instance)
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

        public Order_Details Get(int OrderID)
        {
            return db.Order_Details.FirstOrDefault(x => x.OrderID == OrderID);
        }

        public IQueryable<Order_Details> GetAll()
        {
            return db.Order_Details.OrderBy(x => x.OrderID);
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