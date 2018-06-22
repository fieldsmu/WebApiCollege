using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCollege.Models {
	public class Student {

		public int Id { get; set; }
		public string Name { get; set; }
		public int SAT { get; set; }

		public int MajorId { get; set; }
		public virtual Major Major { get; set; }

		public Student() {

		}
	}
}