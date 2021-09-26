using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace тестове_xn__80aafim4ba8l_2.Models
{
    public class ContactCreateModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "'Email' is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'FirstName' is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "'LastName' is required")]
        public string LastName { get; set; }
    }
}
