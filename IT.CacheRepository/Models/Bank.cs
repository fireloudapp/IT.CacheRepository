using System;

namespace IT.CacheRepository.Models
{
    public class Bank
    {
        public long BankAccountID { get; set; }

        public string Name { get; set; }
     
        public string IBAN { get; set; }

        public string SWIFT   { get; set; }

        public DateTime UpdateDate { get; set; }

    }

}
