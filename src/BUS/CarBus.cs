using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS {
	public class CarBus {
		CarDAL carDAL = new CarDAL();
		public DataTable getAll() {
			return carDAL.getAllCar();
		}
		public List<FeatureDTO> getAllCar(int _id) {
			return carDAL.getAllFeaturesByIdCar(_id);
		}
		public bool addCar(CarDTO carDTO) {
			return carDAL.addCar(carDTO);
		}
		public int findCarByName(string name) {
			return carDAL.findCarByName(name);	
		}
		public bool addCarFeature(int idCar, int featureId) {
			return carDAL.addCarFeature(idCar, featureId);	
		}
		public bool removeCar(int idCar) {
			return carDAL.removeCar(idCar);
		}

		public bool updateCar(CarDTO carDTO) {
			return carDAL.updateCar(carDTO);
		}

		public bool deleteCarFeature(int idCar) {
			return carDAL.deleteCarFeature(idCar);
		}

		public DataTable getByTypeCarID(int typeCarID) {
			return carDAL.getByTypeCarID(typeCarID);
		}
		
		public CarDTO getCar(int idCar) {
			try {
				DataTable dataTable = carDAL.getCarById(idCar);
				DataRow row = dataTable.Rows[0];
				int carID = Convert.ToInt32(row["carID"]);
				string carName = row["carName"].ToString();
				string typeName = row["typeName"].ToString();
				string nhienLieuID = row["nhienLieuID"].ToString();
				float price = float.Parse(row["price"].ToString());
				CarDTO carDTO = new CarDTO();
				carDTO.CarID = carID;
				carDTO.CarName = carName;
				carDTO.NhienLieuID = nhienLieuID;
				return carDTO;
			} catch(Exception e) {
				return null;
			}
		}

		public bool findStatusCar(int idCar) {
			string sql = "SELECT * FROM MYORDER WHERE carId = @id and status = 0";
			DataTable dataTable = Connection.selectQuery(sql ,new object[] {idCar});
			if(dataTable.Rows.Count > 0 ) {
				return false;
			}
			return true;
		}
    }
}
