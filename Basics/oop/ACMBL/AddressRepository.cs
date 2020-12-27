using System.Collections.Generic;

namespace ACMBL
{
    public class AddressRepository
    {
        public Address Retrieve(int addressId)
        {

            var address = new Address(addressId);


            if (addressId == 1)
            {
                address.Type = AddressType.Home;
                address.StreetLine1 = "Warchałowskiego";
                address.StreetLine2 = "1/72";
                address.City = "Modlin";
                address.StateProvince = "wieckie";
                address.Country = "SanEscobar";
                address.PostalCode = "09234";
            }

            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var addresses = new List<Address>();

            var address = new Address(1)
            {
                Type = AddressType.Home,
                StreetLine1 = "Warchałowskiego",
                StreetLine2 = "1/72",
                City = "Modlin",
                StateProvince = "wieckie",
                Country = "SanEscobar",
                PostalCode = "09234"
            };
            addresses.Add(address);

            address = new Address(2)
            {
                Type = AddressType.Delivery,
                StreetLine1 = "Proznao",
                StreetLine2 = "44a",
                City = "Zabki",
                StateProvince = "kosie",
                Country = "SanEscobar",
                PostalCode = "05534"
            };
            addresses.Add(address);

            address = new Address(3)
            {
                Type = AddressType.Work,
                StreetLine1 = "Wargo",
                StreetLine2 = "231",
                City = "Azkan",
                StateProvince = "wieckie",
                Country = "Escobar",
                PostalCode = "088"
            };
            addresses.Add(address);

            return addresses;
        }

        public bool Save(Address address)
        {
            return true;
        }

    }
}