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
            newUser,
            regUser,
            actUser
        }

        public enum Level : int
        {
            standard,
            premium
        }

        public enum Dominio : int
        {
            shapps
        }

        public enum UserType : byte
        {
            person,
            company
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
