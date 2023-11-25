using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CarDTO {
        private int carID;
        private string carName;
        private int typeCarID;
        private string nhienLieuID;
        public CarDTO() { } 
        public CarDTO(int carID, string carName, int typeCarID, string nhienLieuID) {
			this.carID = carID;
			this.carName = carName;
			this.typeCarID = typeCarID;
			this.nhienLieuID = nhienLieuID;
		}
		public int CarID { get => carID; set => carID = value ; }
		public string CarName { get => carName; set => carName = value ; }
		public int TypeCarID { get => typeCarID; set => typeCarID = value; }
		public string NhienLieuID { get => nhienLieuID; set => nhienLieuID = value; }
	
	}
}
