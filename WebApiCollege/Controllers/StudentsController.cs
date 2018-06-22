using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCollege.Models;
using WebApiCollege.Utility;

namespace WebApiCollege.Controllers {
	public class StudentsController : ApiController {
		CollegeDbContext db = new CollegeDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Students.ToList()
			};
		}

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null) {
				new JsonResponse {
					Result = "Failed",
					Message = "Get requires a valid id"
				};
			}
			return new JsonResponse {
				Data = db.Students.Find(id)
			};
		}

		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Student student) {
			if (student == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of a Student"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the attributes is invalid"
				};
			}
			db.Students.Add(student);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Student student) {
			if (student == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of a Student"
				};
			}
			var stu = db.Students.Find(student.Id);
			if (stu == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Could not find the student"
				};
			}
			stu.Name = student.Name;
			stu.SAT = student.SAT;
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the attributes is invalid"
				};
			}
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Student student) {
			if (student == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of a Student"
				};
			}
			var stu = db.Students.Find(student.Id);
			db.Students.Remove(stu);
			db.SaveChanges();
			return new JsonResponse();
		}
	}
}
