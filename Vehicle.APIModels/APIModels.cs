using System;

namespace Vehicle.APIModels
{
    public class APIModels
    {

    }
    public class Vehicle
    {
        public VehicleInfo[] VehicleInfos { get; set; }
    }

    public class VehicleInfo
    {
        public int id { get; set; }
        public string model { get; set; }
        public string colour { get; set; }
        public string manufacturer { get; set; }
        public Saleshistory[] salesHistory { get; set; }
    }

    public class Saleshistory
    {
        public int year { get; set; }
        public int vehiclesSold { get; set; }
    }
    public class VehicleModels
    {
        public string Model { get; set; }
        public int NumberOfSales { get; set; }
    }
}
