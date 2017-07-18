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

        public IEnumerable<Order_Details> OrderDetails
        {
            get
            {
                return orderDetailRepository.GetAll();
            }
        }

        public OrderController()
        {
            this.orderRepository = new OrderRepository();
            this.orderDetailRepository = new OrderDetailRepository();
        }

        public ActionResult Index()
        {
            var orders = orderRepository.GetAll().ToList();
            return View(orders);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var orderdetail = this.orderDetailRepository.Get(id.Value);
                return View(orderdetail);

            }
        }
    }
}