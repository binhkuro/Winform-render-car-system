using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Connection
    {
		public static SqlConnection conn;
		public static void connect() {
			string s = "Data Source=HuyHoa2003\\SQLEXPRESS;Initial Catalog=midterm;Integrated Security=True";
			conn = new SqlConnection(s);
			conn.Open();
		}

		public static bool actionQuery(string sql , object[] param=null) {
			connect();
			SqlCommand cmd = new SqlCommand(sql, conn);
			if(param != null ) {
				string[] listPara = sql.Split(' ');
				int i = 0;
				foreach (string item in listPara) {
					if (item.Contains('@')) {
						cmd.Parameters.AddWithValue(item, param[i]);
						i++;
					}
				}
			}
			if (cmd.ExecuteNonQuery() > 0) {
				return true;
			}
			return false;
		}

		public static DataTable selectQuery(string sql, object[] param = null) { 
			connect();
			SqlCommand cmd = new SqlCommand (sql, conn);	
			if(param != null ) {
				string[] listPara = sql.Split(' ');
				int i = 0;
				foreach (string item in listPara) {
					if (item.Contains('@')) {
						cmd.Parameters.AddWithValue(item, param[i]);
						i++;
					}
				}
			}
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd)) {
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				return dataTable;
			}
		}
	}
}
