﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Rentals.DL.Interfaces;
using Rentals.Web.Interfaces;

namespace Rentals.Web.Models
{
	public class RentingUserCreatorViewModel : BaseViewModel, IValidatableObject, IAfterFetchModel
	{
		public RentingUserCreatorViewModel()
		{
			// Inicializační hodnoty, připravím si je tady, abych se o ně nemusel starat ve view.
			var today = DateTime.Today;

			this.StartsAtDate = today;
			this.EndsAtDate = today;

			this.Items = new List<ItemViewModel>();
		}

		public int RentalId
		{
			get;
			set;
		}

		/// <summary>
		/// Začátek výpůjčky - datum.
		/// </summary>
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = nameof(Localization.Localization.Renting_StartsAt), ResourceType = typeof(Localization.Localization))]
		public DateTime StartsAtDate
		{
			get;
			set;
		}

		/// <summary>
		/// Začátek výpůjčky - čas.
		/// </summary>
		[Required]
		[DataType(DataType.Time)]
		[Range(typeof(TimeSpan), "00:00", "23:59")]
		public TimeSpan StartsAtTime
		{
			get;
			set;
		}

		/// <summary>
		/// Začátek výpůjčky.
		/// </summary>
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = nameof(Localization.Localization.Renting_EndsAt), ResourceType = typeof(Localization.Localization))]
		public DateTime EndsAtDate
		{
			get;
			set;
		}

		/// <summary>
		/// Začátek výpůjčky - čas.
		/// </summary>
		[Required]
		[DataType(DataType.Time)]
		[Range(typeof(TimeSpan), "00:00", "23:59")]
		public TimeSpan EndsAtTime
		{
			get;
			set;
		}
		public DateTime StartsAt => this.StartsAtDate.Add(this.StartsAtTime);

		public DateTime EndsAt => this.EndsAtDate.Add(this.EndsAtTime);

		public ICollection<ItemViewModel> Items
		{
			get;
			set;
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var factory = (IRepositoriesFactory)validationContext.GetService(typeof(IRepositoriesFactory));

			var rental = factory.Rentals.GetById(this.RentalId);

			#region Dates

			if (rental == null)
			{
				// Todle taky nenastane pokud někdo nezedituje kód stránky.
				yield return new ValidationResult(Localization.Localization.Renting_NoRental);
			}
			else if (!rental.IsInWorkingHours(this.StartsAt))
			{
				yield return new ValidationResult(Localization.Localization.Renting_StartsAtNotInWorkingHours, new[] { nameof(this.StartsAtDate) });
			}
			else if (!rental.IsInWorkingHours(this.EndsAt))
			{
				yield return new ValidationResult(Localization.Localization.Renting_EndsAtNotInWorkingHours, new[] { nameof(this.EndsAtDate) });
			}

			if (this.StartsAt >= this.EndsAt)
			{
				yield return new ValidationResult(Localization.Localization.Renting_WrongDate, new[] { nameof(this.StartsAtDate) });
			}

			if (this.StartsAt < DateTime.Now)
			{
				yield return new ValidationResult(Localization.Localization.Renting_DateInPast, new[] { nameof(this.StartsAtDate) });
			}

			#endregion
		}

		public void AfterFetchModel(IRepositoriesFactory repositoriesFactory)
		{
			this.RentalId = this.Rental.Id;

			foreach (var itemToRent in this.User.Basket)
			{
				if (itemToRent.Value == -1)
				{
					var item = repositoriesFactory.Items.GetByUniqueIdentifier(itemToRent.Key);

					this.Items.Add(new ItemViewModel()
					{
						UniqueId = item.UniqueIdentifier,
						CoverImage = item.CoverImage,
						NumberOfItems = 1
					});
				}
				else
				{
					var type = repositoriesFactory.Types.GetByName(itemToRent.Key);

					this.Items.Add(new ItemViewModel()
					{
						Name = type.Name,
						CoverImage = type.ActualItems.FirstOrDefault()?.CoverImage,
						NumberOfItems = type.NonSpecificItems.Count
					});
				}
			}
		}
	}
}
