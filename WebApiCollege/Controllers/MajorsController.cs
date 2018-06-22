using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCollege.Models;
using WebApiCollege.Utility;

namespace WebApiCollege.Controllers {
	public class MajorsController : ApiController {
		CollegeDbContext db = new CollegeDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Majors.ToList()
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
				Data = db.Majors.Find(id)
			};
		}

		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of a Major"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the attributes is invalid"
				};
			}
			db.Majors.Add(major);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of a Major"
				};
			}
			var maj = db.Majors.Find(major.Id);
			maj.Description = major.Description;
			maj.MinSAT = major.MinSAT;
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
		public JsonResponse Remove(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of a Major"
				};
			}
			var maj = db.Majors.Find(major.Id);
			db.Majors.Remove(maj);
			db.SaveChanges();
			return new JsonResponse();
		}
	}
}
