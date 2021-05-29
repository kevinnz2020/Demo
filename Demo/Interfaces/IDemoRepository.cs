using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Interfaces
{
    public interface IDemoRepository
    {
        decimal Discount(decimal listPrice, decimal discount);
        decimal Freight(string scale);

    }
}
