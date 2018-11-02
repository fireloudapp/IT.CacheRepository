using System;
using System.Collections.Generic;

namespace IT.CacheRepository.Models
{
    public class User
    {
        public User()
        {
          
        }

        public enum registrationStatus : byte
        {
            newUser = 0,
            regUser = 1,
            actUser = 2,
        }

        public enum Level : int
        {
            standard = 1,
            premium = 2,
        }

        public enum Dominio : int
        {
            shapps = 1
        }

        public enum UserType : byte
        {
            person = 1,
            company = 2
        }

        public long UserID { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public byte Type { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public List<Portfolio> Portfolios { get; set; }

        public List<Bank> Banks { get; set; }

        public string ProfileRisk { get; set; }

        public decimal TransactionFees { get; set; }

        public decimal EodLiquidity { get; set; }
    }

}
