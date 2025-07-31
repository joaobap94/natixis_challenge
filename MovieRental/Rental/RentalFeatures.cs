﻿using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		public async Task<Rental> Save(Rental rental)
		{
			_movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		public async Task<IEnumerable<Rental>> GetRentalsByCustomerName(string customerName)
		{
			return await _movieRentalDb.Rentals.Where(r => r.CustomerName.Equals(customerName)).ToListAsync();
		}

	}
}
