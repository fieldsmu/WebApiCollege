using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiCollege.Models {
	public class CollegeDbContext : DbContext {

		public DbSet<Major> Majors { get; set; }
		public DbSet<Student> Students { get; set; }

		public CollegeDbContext() : base() {

		}
	}
}