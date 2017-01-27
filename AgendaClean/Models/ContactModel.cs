using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaClean.Models
{
    [Table("Contact")]
    public class ContactModel : IEntity
    {
        public string Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite o nome do contato", AllowEmptyStrings =false)]
        public string Name { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        public DateTime Phone { get; set; }

        public string UserIdRefId { get; set; }

        [ForeignKey("UserIdRefId")]
        public UserModel User { get; set; }

    }
}