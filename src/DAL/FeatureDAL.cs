using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
	public class FeatureDAL {
		SqlCommand command;
		public FeatureDAL() {}
		public List<FeatureDTO> getAllFeature() {
			string sql = "select * from Feature ";
			List<FeatureDTO> features = new List<FeatureDTO>();	
			Connection.connect();	
			using(SqlConnection sqlConnection = Connection.conn) {
				command = new SqlCommand(sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read()) {
					FeatureDTO feature = new FeatureDTO();
					feature.setId(reader.GetInt32(0));
					feature.setNameFeature(reader.GetString(1));
					features.Add(feature);
				}
				sqlConnection.Close();	
			}
			return features;
		}
			
		public FeatureDTO GetFeature(int id) {
			string sql = "select * from CarFeature where CarFeature.carID = @_id ";
			DataTable dataTable = Connection.selectQuery(sql, new object[] { id });
			FeatureDTO feature = new FeatureDTO();
			if (dataTable != null && dataTable.Rows.Count > 0) {
				DataRow row = dataTable.Rows[0];
			}
			return feature; 
		}
	}
}
