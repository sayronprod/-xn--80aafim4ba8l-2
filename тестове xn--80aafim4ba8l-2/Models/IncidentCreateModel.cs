using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace тестове_xn__80aafim4ba8l_2.Models
{
    public class IncidentCreateModel
    {
        [Required(ErrorMessage = "'Description' is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "'Account' is required")]
        public ICollection<AccountCreateModel> Accounts { get; set; }
    }
}
