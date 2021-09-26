using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace тестове_xn__80aafim4ba8l_2.Models
{
    public class AccountCreateModel
    {
        [Required(ErrorMessage = "'Name' is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Contact' is required")]
        public ICollection<ContactCreateModel> Contacts { get; set; }
    }
}
