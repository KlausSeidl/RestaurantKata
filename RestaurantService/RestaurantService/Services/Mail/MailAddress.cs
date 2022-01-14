using System;

namespace RestaurantService.Services.Mail
{
    public class MailAddress : IEquatable<MailAddress>
    {
        public string Address { get; }
        
        #region IEquatable
        public bool Equals(MailAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address == other.Address;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MailAddress)obj);
        }

        public override int GetHashCode()
        {
            return (Address != null ? Address.GetHashCode() : 0);
        }

        public static bool operator ==(MailAddress left, MailAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MailAddress left, MailAddress right)
        {
            return !Equals(left, right);
        }

        public MailAddress(string address)
        {
            Address = address;
        }
        #endregion

    }
}