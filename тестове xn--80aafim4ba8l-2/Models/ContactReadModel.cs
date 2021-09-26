using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace тестове_xn__80aafim4ba8l_2.Models
{
    public class ContactReadModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
    }
}
