using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Interface;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;
        private ICustomerRepository customerRepository;

        public IEnumerable<Order_Details> OrderDetails
        {
            get
            {
                return orderDetailRepository.GetAll();
            }
        }

        public IEnumerable<Customers> Custs
        {
            get
            {
                return customerRepository.GetAll();
            }
        }

        public OrderController()
        {
            this.orderRepository = new OrderRepository();
            this.orderDetailRepository = new OrderDetailRepository();
            this.customerRepository = new CustomerRepository();
        }

        public ActionResult Index()
        {
            var orders = orderRepository.GetAll().ToList();
            return View(orders);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(this.Custs, "CustomerID", "CompanyName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Orders order)
        {
            if (order != null && ModelState.IsValid)
            {
                this.orderRepository.Create(order);
                return RedirectToAction("index");
            }
            else
            {
                return View(order);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            Orders order = this.orderRepository.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = this.orderRepository.Get(id);
            
            this.orderRepository.Delete(order);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            Orders order = this.orderRepository.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            if (ModelState.IsValid)
            {
                this.orderRepository.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var orderdetail = this.orderDetailRepository.GetOrderDetailnProduct(id.Value);
                return View(orderdetail);

            }
        }
    }
}