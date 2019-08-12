namespace Bravi.ContactList.API.Models
{
    public class ContactModel
    {
        public ContactModelType Type { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Represents the data according to <see cref="ContactModel.Type"/> set.
        /// </summary>
        public string ContactData { get; set; }
    }

    public enum ContactModelType
    {
        Email = 1,
        WhatsApp = 2,
        Phone = 3
    }
}
