using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender {Male,Female,Other}
    public class AccountOpenning
    {
        private static int _custemerid=1000;
        public string  CustomerID {get; set;}
        public string CustomerName{get; set;}
        public double Balance{get; set;}
        public Gender Gender{get; set;}
        public long PhoneNumber{get; set;}
        public string MailID{get; set;}
        public DateTime DateOfBirth{get; set;}

        public  AccountOpenning(string customername , double balance , Gender gender , long phonenumber , string mailid ,DateTime dateofbirth)
        {
            CustomerID="HDFC"+ ++_custemerid;
            CustomerName=customername;
            Balance=balance;
            Gender=gender;
            PhoneNumber=phonenumber;
            MailID =mailid;
            DateOfBirth=dateofbirth;
        }
         public  AccountOpenning(string customer)
        {
           
            string[] customers = customer.Split(",");
            _custemerid=int.Parse(customers[0].Remove(0 , 4));
            CustomerID=customers[0];
            CustomerName=customers[1];
            Balance=int.Parse(customers[2]);
            Gender=Enum.Parse<Gender>(customers[3]);
            PhoneNumber=long.Parse(customers[4]);
            MailID =customers[5];
            DateOfBirth=DateTime.ParseExact(customers[6], "dd/MM/yyyy" , null);
        }

    }
}