using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Models
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_contacts")]
        public int ContactsId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Necesitamos tu nombre")]
        [MaxLength(50)]
        [NotNull]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Digita un correo válido")]
        [MaxLength(30)]
        [NotNull]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [NotNull]
        [MaxLength(30)]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength(50)]
        [NotNull]
        public string City { get; set; }


    }
}
