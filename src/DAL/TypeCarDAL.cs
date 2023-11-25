using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
	public class TypeCarDAL {
		SqlCommand command;
		public TypeCarDAL() { }
		public List<CarTypeDTO> getAll() {
			string sql = "select * from TypeCar ";
			List<CarTypeDTO> features = new List<CarTypeDTO>();
			Connection.connect();
			using (SqlConnection sqlConnection = Connection.conn) {
				command = new SqlCommand(sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read()) {
					CarTypeDTO carTypeDTO  = new CarTypeDTO();
					carTypeDTO.setTypeCarID(reader.GetInt32(0));
					carTypeDTO.setTypeName(reader.GetString(1));
					features.Add(carTypeDTO);
				}
				sqlConnection.Close();
			}
			return features;
		}

		public DataTable getAllTypeCar() {
			string sql = "select * from TypeCar ";
			return Connection.selectQuery(sql); 
		}

		public DataTable getCarType(int id) {
            string sql = "select * from TypeCar where typeCarID = @id ";
            return Connection.selectQuery(sql, new object[] { id });
        }
	}
}
