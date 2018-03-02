using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DI_AOP.Models
{
    public class Character
    {
        public Character() { }
        public Character(string name)
        {
            Name = name;
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }



}
