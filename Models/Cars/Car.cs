using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models.Cars
{
    [Table("Cars", Schema = "is01")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public Mark Mark { get; set; }
        public Model Model { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public BaseState State { get; set; }

        public ICollection<Inspection> Inspections { get; set; }
        
        public Car() {}
    }
}