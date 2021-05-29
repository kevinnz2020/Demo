using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Demo.Controllers
{
    
    public class DemoController : Controller
    {
        private readonly IDemoRepository _demoRepository;
        WeightRanges weightRanges = new WeightRanges();

        public DemoController(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
            LoadWeightRanges();
        }
        public void LoadWeightRanges()
        {  

            weightRanges.WeightList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
        }

        public IActionResult Index()
        {    
            DiscountModel model = new DiscountModel();
            model.WeightRanges = weightRanges.WeightList.ToList();

            return View(model);
        }
        public IActionResult View2()
        {
            DiscountModel model = new DiscountModel();
            model.WeightRanges = weightRanges.WeightList.ToList();

            return View(model);
        }
        [HttpPost]
        public JsonResult View2(string listprice, string discount,string weightId)
        {
            decimal _listprice = Decimal.Parse(listprice);
            decimal _discount = Decimal.Parse(discount);


            decimal lessDiscount = _demoRepository.Discount(_listprice, _discount);
            decimal afterDiscount = _listprice - _discount;

            decimal freight = _demoRepository.Freight(weightId);

            DiscountModel model = new DiscountModel();

            model.LessDiscount = _discount;
            model.AfterDiscount = afterDiscount;
            model.PlusFreight = freight;
            model.Net = afterDiscount + freight;


            return Json(model, new { Success = true });
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

            model.WeightRanges = weightRanges.WeightList.ToList();

            ViewData["result"] = model;

            return View(model);
        }

    }
}
