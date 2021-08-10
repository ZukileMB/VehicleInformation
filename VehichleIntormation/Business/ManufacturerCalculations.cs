using APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehichleIntormation.Business
{
    public class ManufacturerCalculations:IBusinessCalculations
    {
        public int TotalSales(Saleshistory[] saleshistories)
        {
            return saleshistories.Where(x => x.year >= 2011 && x.year <= 2020).Select(n => n.vehiclesSold).Sum();
        }
    }
}