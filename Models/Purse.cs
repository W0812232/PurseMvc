using System;
using System.ComponentModel.DataAnnotations;

namespace PurseMvc.Models
{
    public class Purse
    {
        public int id { get; set; }
        public string Product { get; set; } //name of the purse
        public string Style { get; set; } //style/type of purse such as sachel, mini, bucket


        public decimal Price { get; set; } //cost
        public string Color { get; set; } //colour of the bag without the u
        public string Material { get; set; } //Primary/selling material the bag is made of

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } //date the bag was put up for sale

        public int CustomerReview { get; set; } //customer review

    }
}