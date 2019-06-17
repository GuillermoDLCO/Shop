namespace Shop.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //Precios con formato currency 2, muestra el simbolo de moneda. C2 separacion de miles
        //y con 2 decimales. ApplyFormatInEditMode = false para que no tengamos ese formato
        //al traer el valor para modificar, solo es para mostrar
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        // '?' significa que el valor puede tener nulo
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        //N2, numerico de 2. Aui no se pone simbolo de moneda. Separador de miles y 2 decimales
        public double Stock { get; set; }

        //Se establece relacion con user, uno a varios. Un usuario tiene muchos productos
        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }

                return $"https://shopdlc.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }

    }

}
