using AutoMapper;
using NBT.Core.Common;
using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.Data;
using NBT.Web.Framework.Extensions;
using NBT.Web.Framework.Models.Cart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class CartController : Controller
    {
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        IUnitOfWork _uow;
        public CartController(
            IOrderService orderService,
            IOrderItemService orderItemService,
            IUnitOfWork uow)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _uow = uow;
        }
        public ActionResult Index()
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                return View(listItems);
            }
            return RedirectToAction("Index", "Tour");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(OrderItemVm item)
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);

                if (listItems.Any(x => x.Alias == item.Alias && x.FromDate == item.FromDate && x.ToDate == item.ToDate))
                {
                    listItems.First(x => x.Alias == item.Alias && x.FromDate == item.FromDate && x.ToDate == item.ToDate).Quantity++;
                }
                else
                {
                    item.Quantity = 1;
                    listItems.Add(item);
                }
                cartCookie.Value = JsonConvert.SerializeObject(listItems);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Set(cartCookie);
            }
            else
            {
                var listItems = new List<OrderItemVm>();
                item.Quantity = 1;
                listItems.Add(item);
                cartCookie.Value = JsonConvert.SerializeObject(listItems);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cartCookie);
            }
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(OrderVm order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                var newOrderItem = Mapper.Map<List<OrderItem>>(listItems);
                var newOrder = new Order();
                newOrder.UpdateOrder(order);

                foreach (var item in newOrderItem)
                {
                    item.FromDate = item.FromDate.UtcDateTime;
                    item.ToDate = item.ToDate.UtcDateTime;
                }

                _uow.BeginTran();
                _orderService.Add(newOrder);
                _orderItemService.Add(newOrderItem);
                _uow.CommitTran();
                cartCookie.Expires = DateTime.Now.AddDays(-180);
                Response.Cookies.Add(cartCookie);
                return RedirectToAction("Index", "Tour");
            }
            return RedirectToAction("Index", "Tour");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var model = new OrderVm();
                return View(model);
            }
            return RedirectToAction("Index", "Tour");
        }

        private HttpCookie CheckCart()
        {
            HttpCookie cartCookie;
            if (Request.Cookies[SystemConstants.Cart] != null)
                return Request.Cookies[SystemConstants.Cart];
            else
            {
                cartCookie = new HttpCookie(SystemConstants.Cart);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                cartCookie.Value = "";
                return cartCookie;
            }
        }
    }
}