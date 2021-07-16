using Compugraf.Application.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Compugraf.Application.ViewModel
{
    public class CreatePersonVm
    {

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Nacionalidade obrigatório")]
        public string Nationality { get; set; }

        [CPF]
        [Required(ErrorMessage = "CPF obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "CEP obrigatório")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Logradouro obrigatório")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Cidade obrigatória")]
        public string City { get; set; }

        [Required(ErrorMessage = "Estado obrigatório")]
        public string State { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "E-mail obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public string PhoneNumber { get; set; }
    }
}
