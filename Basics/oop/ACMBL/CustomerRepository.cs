using System.Collections.Generic;
using System.Linq;
namespace ACMBL
{
    public class CustomerRepository
    {
        
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        private AddressRepository addressRepository { get; set; }

        public Customer Retrieve(int customerId)
        {
            var customer = new Customer(customerId);
            
            //TODO retrieve the data
            
            
            //hardcoded
            if (customerId == 1)
            {
                customer.FirstName = "Ab";
                customer.LastName = "Ced";
                customer.EmailAddress = "ab@ced.com";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            }
            
            return customer;
        }

        public bool Save(Customer customer)
        {

            return true;
        }
    }
}