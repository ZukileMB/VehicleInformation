using APIModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace APITests
{
    [TestClass]
    public class TestingAPI
    {
        private List<VehicleInfo> GetTestData()
        {
            string jsonData;

            foreach (string file in Directory.GetFiles(@"C:\Users\User1\Documents\Visual Studio 2019\VehichleIntormation\APITests\TestData"))
            {
                jsonData = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<List<VehicleInfo>>(jsonData);
            }
            throw new Exception("Test JSon file not found");
        }

        [TestMethod]
        public async Task TestModelsSold()
        {
            APICommunication.APIConnect aPI_Connect = new APICommunication.APIConnect("https://localhost:44306/");
            var vehicle = GetTestData();
            var response = await aPI_Connect.PostAsync("api/VehicleInfo/ModelsSold", vehicle);
            if (response.IsSuccessStatusCode)
            {
                var ResponseList = response.Content.ReadAsAsync<List<VehicleModels>>().Result;
                foreach (var item in ResponseList)
                {
                    Console.WriteLine($"{item.model} - {item.NumberOfSales}");
                }

            }
            else
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }


        }

        [TestMethod]
        public async Task TestManufacturerSales()
        {
            APICommunication.APIConnect aPI_Connect = new APICommunication.APIConnect("https://localhost:44306/");
            var vehicle = GetTestData();
            var response = await aPI_Connect.PostAsync("api/VehicleInfo/ManufacturerSales", vehicle);
            if (response.IsSuccessStatusCode)
            {
                var ResponseList = response.Content.ReadAsAsync<List<VehicleModels>>().Result;
                foreach (var item in ResponseList)
                {
                    Console.WriteLine($"{item.manufacturer} - {item.NumberOfSales}");
                }

            }
            else
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }

        [TestMethod]
        public async Task TestTotalSales()
        {
            APICommunication.APIConnect aPI_Connect = new APICommunication.APIConnect("https://localhost:44306/");
            var vehicle = GetTestData();
            var response = await aPI_Connect.PostAsync("api/VehicleInfo/TotalSalesAcrossManufacturers", vehicle);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Total sales across all Manufacturers ={response.Content.ReadAsStringAsync().Result}");

            }
            else
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }

        [TestMethod]
        public async Task TestColourSales()
        {
            APICommunication.APIConnect aPI_Connect = new APICommunication.APIConnect("https://localhost:44306/");
            var vehicle = GetTestData();
            var response = await aPI_Connect.PostAsync("api/VehicleInfo/ColourSales", vehicle);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Most sold colour is {response.Content.ReadAsStringAsync().Result}");

            }
            else
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
