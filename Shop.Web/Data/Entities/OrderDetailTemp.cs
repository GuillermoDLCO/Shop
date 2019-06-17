﻿namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetailTemp : IEntity
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Product Product { get; set; }

        //Este campo es para guardar el historico del precio en ese momento de la venta
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value => this.Price * (decimal)this.Quantity;
    }

}