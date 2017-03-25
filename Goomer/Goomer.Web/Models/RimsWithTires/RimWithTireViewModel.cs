using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.RimsWithTires
{
    public class RimWithTireViewModel : IMapTo<RimWithTire>
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

        [Required(ErrorMessage = "Моля въведете скоростен индекс.")]
        public string SpeedIndex { get; set; }

        [Required(ErrorMessage = "Моля въведете тегловен индекс.")]
        public string WeightIndex { get; set; }

        [Required(ErrorMessage = "Моля въведете височина.")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Моля въведете ДОТ.")]
        [Range(1000, 9999, ErrorMessage = "Дот може да е между 1000 и 9999.")]
        public int Dot { get; set; }

        [Required(ErrorMessage = "Моля въведете дълбочина на грайфера.")]
        public double GrappleMm { get; set; }

        [Required(ErrorMessage = "Моля въведете сезонност.")]
        public string Season { get; set; }

        [Required(ErrorMessage = "Моля въведете разстояние между болтовете.")]
        public double SpaceBetweenBolts { get; set; }

        [Required(ErrorMessage = "Моля въведете брой болтове.")]
        public int NumberOfBolts { get; set; }

        [Required(ErrorMessage = "Моля въведете централен отвор.")]
        public double CentralHoleSize { get; set; }
    }
}