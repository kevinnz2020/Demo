using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class WeightRanges
    {
        public List<SelectListItem> WeightList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "> 0 <=1 kg " },
            new SelectListItem { Value = "2", Text = "> 1 <= 2 kg " },
            new SelectListItem { Value = "3", Text = "> 2 <=5 kg"  },
            new SelectListItem { Value = "4", Text = "> 5 <= 10 kg"  },
          
        };
    }
}
