using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestApi.Models.Cars;

namespace RestApi.Models
{
    [Table("Inspections", Schema = "is01")]
    public class Inspection
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        
        public Car Car { get; set; }
    }
}