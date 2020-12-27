namespace ACMBL
{
    
    public enum AddressType
    {
        Home,
        Work,
        Delivery
    }
    public class Address
    {
        public Address()
        {
        }
        
        public Address(int addressId)
        {
            this.AddressId = addressId;
        }

        public int AddressId { get; private set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public AddressType Type {get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (PostalCode == null) isValid = false;

            return isValid;
        }
    }
}