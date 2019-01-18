using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User : EntityModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }


        public string UserRole { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public int UserStatus { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime Registered { get; set; }

        public string Phone { get; set; }
    }
}
