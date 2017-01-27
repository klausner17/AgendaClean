using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaClean.Models
{
    [Table("User")]
    public class UserModel  : IEntity
    {
        public string Id { get; set; }

        [Display(Name ="Login")]
        [Required(ErrorMessage = "Preencha o login do usuário", AllowEmptyStrings =false)]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha o login do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<ContactModel> Contacts { get; set; }

        public UserModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}