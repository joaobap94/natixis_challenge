using System.ComponentModel.DataAnnotations;
namespace MovieRental.Customer
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Rental.Rental> Rentals { get; set; } = new List<Rental.Rental>();
    }
}
