using System;
using System.ComponentModel.DataAnnotations;

namespace apiweb
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener un minimo de 3 caracteres y maximo de 50")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "El apellido debe tener un minimo de 3 caracteres y maximo de 50")]
        public string Surname { get; set; }
        [Required] 
        public int Age { get; set; }
        public DateTime Date { get; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public bool? State { get; set; }
    }
}
