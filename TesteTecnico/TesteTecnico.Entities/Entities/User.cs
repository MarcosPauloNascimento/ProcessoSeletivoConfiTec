using System;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Entities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int SchoolingId { get; set; }
    }
}
