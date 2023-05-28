namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null;

        public string LastName { get; set; } = null;

        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; } = null;
        public ICollection<Product> ProductsBought { get; set; } = null;
    }
}