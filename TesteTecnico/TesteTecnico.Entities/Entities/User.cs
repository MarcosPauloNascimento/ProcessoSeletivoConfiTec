using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteTecnico.Entities.Entities.Enums;

namespace TesteTecnico.Entities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int SchoolingId { get; set; }
    }
}
