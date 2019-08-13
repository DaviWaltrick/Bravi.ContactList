using System.Collections.Generic;

namespace Bravi.ContactList.API.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContactModel> contacts { get; set; }
    }
}
