using System;
using System.ComponentModel.DataAnnotations;
using TesteTecnico.Entities.Entities.Enums;

namespace TesteTecnico.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Schooling Schooling { get; set; }
    }
}
