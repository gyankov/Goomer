using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.Rims
{
    public class RimViewModel : IMapTo<Rim>
    {
        [Required(ErrorMessage = "Моля въведете марка.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Моля въведете модел.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Моля въведете местонахождение.")]
        public string Siting { get; set; }

        [Required(ErrorMessage = "Моля въведете брой.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Моля въведете цена.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Моля въведете цолаж.")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Моля въведете широчина.")]
        public double Width { get; set; }

        public bool IsBrandNew { get; set; }

        [MaxLength(200, ErrorMessage = "Описанието е до 200 символа.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Моля въведете разстояние между болтовете.")]
        public double SpaceBetweenBolts { get; set; }

        [Required(ErrorMessage = "Моля въведете брой болтове.")]
        public int NumberOfBolts { get; set; }

        [Required(ErrorMessage = "Моля въведете централен отвор.")]
        public double CentralHoleSize { get; set; }

    }
}