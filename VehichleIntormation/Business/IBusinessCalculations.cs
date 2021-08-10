using APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehichleIntormation.Business
{
    public interface IBusinessCalculations
    {
        int TotalSales(Saleshistory[] saleshistories);

    }
}

