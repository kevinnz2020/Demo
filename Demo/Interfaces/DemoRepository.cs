using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Interfaces
{
    public class DemoRepository : IDemoRepository
    {
        decimal freight;
        public decimal Discount(decimal listPrice, decimal discount)
        {
            return (listPrice*discount) / 100;
        }
        public decimal Freight(string scale)
        {
            switch (scale)
            {
                case "1":
                    freight = (decimal)2.5;
                    break;

                case "2":
                    freight = (decimal)4.5;    
                    break;

                case "3":
                    freight = 10;
                    break;
                case "4":
                    freight = (decimal)18.5;
                    break;
            }
            return freight;
        }
    }
}
