

using System.Data.Entity.Spatial;

namespace Common.Interfaces
{
    public interface IGoogleService
    {
        DbGeography FindeLocationByPlz(string plz);


        DbGeography FindeLocationByAdress(string plz, string street, string ort);

    }
}
