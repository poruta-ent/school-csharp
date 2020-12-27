using System;
using System.Collections.Generic;
using Commmon;

namespace ACMBL
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer():this(0)
        {     
        }
        public Customer(int customerId)
        {
            this.CustomerId = customerId;
            AddressList = new List<Address>();
        }
        
        public List<Address> AddressList { get; set; }
        public int CustomerId { get; private set; }
        public int CustomerType { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FullName
        { 
            get
            {
                string fullName = FirstName;
                if(!string.IsNullOrWhiteSpace(LastName))
                {
                    if(!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += " ";
                    }
                    fullName += LastName;
                }
                return fullName;
            }
        }
        public static int InstanceCount { get; set; }

        public string Log() =>
            $"{CustomerId}: {FullName}/tEmail:{EmailAddress}/tStatus:{EntityState.ToString()}";
        
        public override string ToString() => FullName;

        public override bool Validate()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

    }
}
