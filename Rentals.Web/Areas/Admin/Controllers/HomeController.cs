﻿using Microsoft.AspNetCore.Mvc;
using Rentals.DL.Interfaces;
using Rentals.Web.Models;

namespace Rentals.Web.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
	{
		public HomeController(IRepositoriesFactory factory) : base(factory)
		{
		}

		public ActionResult Index()
		{
			var model = FetchModel<BaseViewModel>();

			return View(model);
		}
	}
}