﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rentals.Common.Enums;
using Rentals.DL.Entities;
using Rentals.DL.Interfaces;

namespace Rentals.Web.Data
{
	public static class Seed
	{
		public static async Task CreateData(IServiceProvider serviceProvider, IConfiguration configuration)
		{
			// Přidání rolí
			var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

			foreach (var type in Enum.GetValues(typeof(RoleType)))
			{
				// Pokud role neexistuje, tzn. jedná se o první nasazení aplikace, role vytvořím
				var roleExist = await roleManager.RoleExistsAsync(type.ToString());
				if (!roleExist)
				{
					await roleManager.CreateAsync(new Role((RoleType)type, type.ToString()));
				}
			}

			var user = await userManager.FindByNameAsync(configuration.GetSection("UserSettings")["UserName"]);

			// Pokud admin účet neexistuje, vytvořím ho
			if (user == null)
			{
				var poweruser = new User()
				{
					UserName = configuration.GetSection("UserSettings")["UserName"]
				};

				string userPassword = configuration.GetSection("UserSettings")["UserPassword"];

				var createPowerUser = await userManager.CreateAsync(poweruser, userPassword);
				if (createPowerUser.Succeeded)
				{
					// Přidání Admin role
					await userManager.AddToRoleAsync(poweruser, RoleType.Administrator.ToString());
				}
			}

			var context = (IRepositoriesFactory)serviceProvider.GetService(typeof(IRepositoriesFactory));

			if (context.Rentals.GetFirst() == null)
			{
				context.Rentals.Add(new Rental()
				{
					Name = configuration.GetSection("RentalSettings")["RentalName"],
					StartsAt = new TimeSpan(int.Parse(configuration.GetSection("RentalSettings")["StartsAt"]), 0, 0),
					EndsAt = new TimeSpan(int.Parse(configuration.GetSection("RentalSettings")["EndsAt"]), 0, 0),
					MinTimeUnit = int.Parse(configuration.GetSection("RentalSettings")["MinTimeUnit"]),
					ContactEmail = configuration.GetSection("RentalSettings")["ContactEmail"]
				});

				context.SaveChanges();
			}

			await SeedTestData.Create(context, userManager);

			context.Dispose();
		}
	}
}