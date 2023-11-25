using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
	public class CarDAL {
		SqlCommand command;
		public CarDAL() { }
		public DataTable getAllCar() {
			string sql = "select carID  , carName , TypeCar.typeName , nhienLieuID from car  inner join TypeCar on TypeCar.typeCarID = car.typeCarID\r\n ";
			return Connection.selectQuery(sql);
		}

		public List<FeatureDTO> getAllFeaturesByIdCar(int _id) {
			string sql = "select * from CarFeature\r\ninner join Feature on CarFeature.featureID = Feature.id\r\nwhere CarFeature.carID = @_id ";
			List<FeatureDTO> features = new List<FeatureDTO>();
			Connection.connect();
			using (SqlConnection connection = Connection.conn) {
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@_id", _id);
				using (SqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						FeatureDTO feature = new FeatureDTO();
						feature.setNameFeature(reader.GetString(3));
						features.Add(feature);
					}
				}
			}
			return features;
		}

		public bool addCar(CarDTO car) {
			string carName = car.CarName;	
			int typeCarID = car.TypeCarID;
			string NhienLieuID = car.NhienLieuID;
			String sql = "insert into car(carName , typeCarID , nhienLieuID ) values ( @a , @b , @c ) ";
			return Connection.actionQuery(sql, new object[] { carName, typeCarID, NhienLieuID });
		}

		public int findCarByName(string carName) {
			string sql = "  select carID from car where [carName] = @CarName";
			DataTable dataTable = Connection.selectQuery(sql, new object[] {carName});
			if (dataTable.Rows.Count > 0) {
				int carId = Convert.ToInt32(dataTable.Rows[0]["carID"]);
				return carId;
			}
			return -1;
		}

		public bool addCarFeature(int idCar, int featureId) {
			string sql = "insert into CarFeature(carID, featureID) values ( @a , @b ) ";
			return Connection.actionQuery(sql, new object[] { idCar, featureId });
		}

		public bool removeCar(int idCar) {
			string sql = "delete from car where carID = @id ";
			return Connection.actionQuery(sql, new object[] { idCar });
		}

		public bool updateCar(CarDTO carDTO) {
			string sql = "" +
				"UPDATE [dbo].[Car]\r\n   " +
				"SET [carName] = @a \r\n ,[typeCarID] = @b \r\n ,[nhienLieuID] = @c \r\n " +
				"WHERE [carID] = @d \r\n";
			return Connection.actionQuery(sql , new object[] { carDTO.CarName, carDTO.TypeCarID, carDTO.NhienLieuID, carDTO.CarID }); 	
		}

		public bool deleteCarFeature(int idCar) {
			string sql = "delete from CarFeature where  carID  = @id ";
			return Connection.actionQuery(sql , new object[] { idCar });
		}

		public DataTable getByTypeCarID(int typeCarID) {
			string sql = "select carID  , carName , TypeCar.typeName , nhienLieuID from car inner join  TypeCar ON TypeCar.typeCarID = car.typeCarID where car.typeCarID = @typeCarID ";
			return Connection.selectQuery(sql, new object[] { typeCarID });	
		}

		public DataTable getCarById(int idCar) {
			throw new NotImplementedException();
		}
    }
}
