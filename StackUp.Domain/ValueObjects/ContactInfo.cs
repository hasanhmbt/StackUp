using System.Text.RegularExpressions;

namespace StackUp.Domain.ValueObjects
{
    public class ContactInfo
    {
        public string Email { get; private set; }
        public string Phone { get; private set; }

        private ContactInfo() { }

        public ContactInfo(string email, string phone)
        {
            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format.", nameof(email));
            if (!IsValidPhone(phone))
                throw new ArgumentException("Invalid phone format.", nameof(phone));

            Email = email;
            Phone = phone;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d{10,15}$");
        }

        public override bool Equals(object obj)
        {
            if (obj is not ContactInfo other)
                return false;

            return Email == other.Email && Phone == other.Phone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, Phone);
        }
    }
}
