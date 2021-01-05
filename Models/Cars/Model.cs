using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models.Cars
{
    [Table("Models", Schema = "is01")]
    public class Model
    {
        [Key]
        public int Id { get; set; }
        
        public Mark Mark { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BaseState State { get; set; }
        public Model() {}
    }
}