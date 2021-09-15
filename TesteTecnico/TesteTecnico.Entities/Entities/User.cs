using System;
using TesteTecnico.Entities.Entities.Enums;

namespace TesteTecnico.Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public Schooling Schooling { get; set; }
    }
}
