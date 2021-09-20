using System;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Escolaridade { get; set; }
    }
}
