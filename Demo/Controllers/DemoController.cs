using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class DemoController : Controller
    {
        private readonly IDemoRepository _demoRepository;

        public DemoController(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var weightRanges = new WeightRanges();

            weightRanges.WeightList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });


            DiscountModel model = new DiscountModel();
            model.WeightRanges = weightRanges.WeightList.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(DiscountModel model)
        {
            decimal discount = _demoRepository.Discount(model.ListPrice, model.Discount);
            decimal afterDiscount = model.ListPrice - discount;

            decimal freight = _demoRepository.Freight(model.WeightId);

            model.LessDiscount = discount;
            model.AfterDiscount = afterDiscount;
            model.PlusFreight = freight;

            model.Net = afterDiscount + freight;


            var weightRanges = new WeightRanges();

            weightRanges.WeightList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            model.WeightRanges = weightRanges.WeightList.ToList();

            ViewData["DiscountModel"]= model;

            return View(model);
        }

    }
}
