using Common.Interfaces;
using GoogleMaps.LocationServices;
using System.Data.Entity.Spatial;

namespace Common.Services
{
    public class GoogleService : IGoogleService
    {
        public DbGeography FindeLocationByPlz(string plz)
        {
            var Adresse = new AddressData()
            {
                Country = "Deutschland",
                Zip = plz,
            };

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Adresse);
            var GeoDaten = DbGeography.FromText("Point(" + point.Longitude.ToString().Replace(',', '.') + " " + point.Latitude.ToString().Replace(',', '.') + " )");
            return GeoDaten;
        }

        public DbGeography FindeLocationByAdress(string plz,string street, string ort)
        {
            var Adresse = new AddressData()
            {
                Address = street,
                Country = "Deutschland",
                Zip = plz,
                City = ort
            };

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Adresse);
            var GeoDaten = DbGeography.FromText("Point(" + point.Longitude.ToString().Replace(',', '.') + " " + point.Latitude.ToString().Replace(',', '.') + " )");
            return GeoDaten;
        }
    }
}

