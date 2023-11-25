using System;
using System.Collections.Generic;
using System.Linq;

namespace DTO
{
    public class TypeCarReport
    {
        public int TypeCarID { get; set; }
        public string TypeName { get; set; }
        public int NumberOfCars { get; set; }
        public decimal TotalOrderAmount { get; set; }

        public TypeCarReport()
        {
            TypeCarID = 0;
            TypeName = "";
            NumberOfCars = 0;
            TotalOrderAmount = 0;
        }

        public TypeCarReport(int typeCarID, string typeName, int NumberOfCars, decimal TotalOrderAmout)
        {
            TypeCarID = typeCarID;
            TypeName = typeName;
            NumberOfCars = NumberOfCars;
            TotalOrderAmount = TotalOrderAmout;
        }

        public void UpdateCarInfo(List<CarDTO> cars, List<OrderDTO> orders)
        {
            NumberOfCars = cars.Count(c => c.TypeCarID == TypeCarID);

            TotalOrderAmount = orders
                .Where(o => cars.Any(c => c.CarID == o.CarID && c.TypeCarID == TypeCarID))
                .Sum(o => (decimal)o.Total);
        }
    }
}