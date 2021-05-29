using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class DiscountModel
    {
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Price must be greater than zero")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal ListPrice { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Discount must be greater than zero")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Discount { get; set; }
        //[Required]
        //[Range(0.1, 10, ErrorMessage = "Weight must be greater than zero and less than 11")]
        //public decimal Weight { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal LessDiscount { get; set; }
       
        public decimal AfterDiscount { get; set; }
      
        public decimal PlusFreight { get; set; }
      
        public decimal Net { get; set; }
        public string WeightId { get; set; }
        public List<SelectListItem> WeightRanges { get; set; }




    }
}
