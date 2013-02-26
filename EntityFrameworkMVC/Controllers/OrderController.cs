using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkMVC.Controllers
{
    using Models;
    using Models.Repositories;

    public class OrderController : Controller
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Customer> customerRepository;

        public OrderController(IRepository<Order> orderRepository, IRepository<Customer> customerRepository )
        {
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            var model = orderRepository.Fetch();
            return View("Index", model);
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            var customers = customerRepository.Fetch().ToList();
            var order = new Order();
            var model = new OrderCustomer()
                            {
                                Customers =
                                    customers.Select(
                                        x =>
                                        new SelectListItem()
                                            {
                                                Text = x.FirstName,
                                                Value = x.ID.ToString()
                                            }),
                                Order = order
                            };

            return View("Create", model);
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(Order order, FormCollection collection)
        {
            try
            {
                var customer = customerRepository.FetchById(int.Parse(collection["Customer"]));
                order.Customer = customer;
                orderRepository.Add(order);
                orderRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
