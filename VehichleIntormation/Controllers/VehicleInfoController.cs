using APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace VehichleIntormation.Controllers
{
    public class VehicleInfoController : ApiController
    {
        [HttpGet]
        public string GetServiceInfo()
        {
            return "VehicleAPI";
        }
        [HttpPost]
        public async Task<List<VehicleModels>> ModelsSold(List<VehicleInfo> vehicle)
        {
            List<VehicleModels> vehicleModels = new List<VehicleModels>();
            Business.ModelCalculations businessCalculations = new Business.ModelCalculations();
            if (vehicle != null)
            {
                foreach (var info in vehicle)
                {
                    VehicleModels vehicleModel = new VehicleModels();
                    vehicleModel.model = info.model;

                    vehicleModel.NumberOfSales = businessCalculations.TotalSales(info.salesHistory);

                    vehicleModels.Add(vehicleModel);
                }
            }
            return vehicleModels;
        }

        [HttpPost]
        public async Task<List<VehicleModels>> ManufacturerSales(List<VehicleInfo> vehicle)
        {
            List<VehicleModels> vehicleModels = new List<VehicleModels>();
            Business.ModelCalculations businessCalculations = new Business.ModelCalculations();
            if (vehicle != null)
            {
                foreach (var info in vehicle)
                {
                    VehicleModels vehicleModel = new VehicleModels();
                    vehicleModel.manufacturer = info.manufacturer;
                    vehicleModel.model = info.model;
                    vehicleModel.NumberOfSales = businessCalculations.TotalSales(info.salesHistory);

                    vehicleModels.Add(vehicleModel);
                }
                return vehicleModels.GroupBy(x => x.manufacturer).Select(m => new VehicleModels { manufacturer = m.First().manufacturer, NumberOfSales = m.Sum(x => x.NumberOfSales) }).ToList();
            }
            return vehicleModels;
        }

        [HttpPost]
        public async Task<int> TotalSalesAcrossManufacturers(List<VehicleInfo> vehicle)
        {
            int totalSales = 0;
            Business.ModelCalculations businessCalculations = new Business.ModelCalculations();
            if (vehicle != null)
            {
                foreach (var info in vehicle)
                {
                    totalSales += businessCalculations.TotalSales(info.salesHistory);
                }
            }
            return totalSales;
        }

        [HttpPost]
        public async Task<string> ColourSales(List<VehicleInfo> vehicle)
        {
            string colour = "";
            List<VehicleModels> vehicleModels = new List<VehicleModels>();
            Business.ModelCalculations businessCalculations = new Business.ModelCalculations();
            if (vehicle != null)
            {
             
                colour= vehicle.GroupBy(x => x.colour).Select(m => new ColoursSales { colour = m.First().colour, count = m.Count() }).OrderByDescending(x=>x.count).First().colour;
            }
            return colour;
        }
    }



}
