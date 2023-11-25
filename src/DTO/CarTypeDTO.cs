using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
	public class CarTypeDTO {
		private int typeCarID;
		private string typeName;
		private int numberSeat;
		private float price;
		public CarTypeDTO(int typeCarID, string typeName, int numberSeat , float price) {
			this.typeCarID = typeCarID;
			this.typeName = typeName;
			this.numberSeat = numberSeat;
			this.price = price;	
		}
		public CarTypeDTO() { }
		public int getTypeCarID() { return typeCarID;}
		public string getTypeName() { return typeName;}
		public int getNumberSeat() {  return numberSeat;}	
		public void setTypeCarID(int typeCarID) {
			this.typeCarID = typeCarID;
		}
		public void setTypeName(string typeName) {
			this.typeName = typeName;
		}
		public void setNumberSeat(int numberSeat) {
			this.numberSeat = numberSeat;
		}
		public float Price { get => price; set => price = value; }
	}
}
