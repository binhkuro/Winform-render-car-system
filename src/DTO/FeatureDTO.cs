using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
	public class FeatureDTO {
		private int id;
		private string nameFeature;
		public FeatureDTO(int id, string nameFeature) { 
			this.id = id;	
			this.nameFeature = nameFeature;
		}
		public FeatureDTO() { }
		public int getId() { return id; }	
		public string getNameFeature() { return nameFeature;}
		public void setNameFeature(string nameFeature) {  this.nameFeature = nameFeature;}
		public void setId(int id) { this.id = id; }
	}
}
		