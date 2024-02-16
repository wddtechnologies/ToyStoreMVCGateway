﻿using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ToyStoreMVCGatewayUI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(140)]
        public string? ProductName { get; set; }
        [Required]
        [MaxLength(250)]
        public string? ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

    }
}

