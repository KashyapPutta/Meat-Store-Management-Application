using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        public string NameOfCustomer { get; set; }
        [Required]
        public long ContactNo { get; set; }
       
    }
}