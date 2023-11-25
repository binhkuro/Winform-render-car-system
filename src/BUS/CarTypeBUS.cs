using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS {
	public class CarTypeBUS {
		TypeCarDAL typeCarDAL = new TypeCarDAL();
		public List<CarTypeDTO> getAll() {
			return typeCarDAL.getAll();
		}
		public DataTable getAllTypeCar() {
			return typeCarDAL.getAllTypeCar();
		}

        public CarTypeDTO getCarType(int id)
        {
            try
            {
                DataTable dataTable = typeCarDAL.getCarType(id);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    CarTypeDTO carTypeDTO = new CarTypeDTO();
                    carTypeDTO.setTypeCarID(Convert.ToInt32(row["typeCarID"]));
                    carTypeDTO.setTypeName(row["typeName"].ToString());
                    carTypeDTO.Price = float.Parse(row["price"].ToString());
                    return carTypeDTO;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
