using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BankAccountOpening
{
    class Program
    {
       public static List<AccountOpenning> accountopenningsList = new List<AccountOpenning>();
        static AccountOpenning currentuser;
        public static void Main()
        {
            FileHandling.Create();
            FileHandling.ReadCSVfile();
            string val = "yes";
            Console.WriteLine("BANK ACCOUNT OPENING !!.");
            do
            {

                Console.WriteLine(" 1 . Registration ");
                Console.WriteLine(" 2 . Login ");
                Console.WriteLine(" 3 . Exit");
                Console.WriteLine("Choose This Option");
                string option1 = Console.ReadLine();


                switch (option1)
                {
                    case "1":
                        {
                            //registration
                            Registration();
                            break;
                        }
                    case "2":
                        {
                            //login
                            Login();
                            break;
                        }
                    case "3":
                        {
                            val = "no";
                            Console.WriteLine("THANK YOU!..");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("INVALID OPTION !");
                            break;
                        }
                }
            } while (val == "yes");
            FileHandling.WriteCSVfile();

        }
        public static void Registration()
        {

            string username = "";
            bool check = false;

            do
            {
                Console.WriteLine("Enter You'r Name ");
                username = Console.ReadLine().Trim();
                if (username.Contains("  ") || string.IsNullOrEmpty(username) || SpecialCharacter(username))
                {
                    check = false;
                    Console.WriteLine("Enter The Valid Name");
                }
                else
                {
                    check = true;
                    break;
                }

            } while (!check);

            double balance1;
            do
            {
                Console.WriteLine("Enter Your Balance");
                string balance = Console.ReadLine().Trim();
                if (double.TryParse(balance, out balance1) && balance1 > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter The Valid Amount");
                }

            } while (true);

            Gender gender1;
            do
            {

                Console.WriteLine("Enter Your Gender Only This Type(male/female/others)");
                string gender = Console.ReadLine();
                if (Enum.TryParse(gender, true, out gender1))
                {
                    if (int.TryParse(gender, out _))
                    {
                        Console.WriteLine("You Are Give The Integer Please Check it and Please Enter The Correct Gender");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            } while (true);

            long number;
            do
            {
                Console.WriteLine("Enter You'r MobileNumber");
                string mobilenumber = Console.ReadLine().Trim();
                if (long.TryParse(mobilenumber, out number) && mobilenumber.Length == 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Mobile Number");
                }


            } while (true);

            Console.WriteLine("Enter You'r MailID ");
            string mailid = Console.ReadLine();
            

            DateTime date;
            do
            {
                Console.WriteLine("Enter You'r DateOfBirth Must Be (dd/MM/yyyy)");

                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Date Formate Please Try Again");
                }
            } while (true);

            AccountOpenning accountlist = new AccountOpenning(username, balance1, gender1, number, mailid, date);
            accountopenningsList.Add(accountlist);
            Console.WriteLine("YOU'R CUTOMERID IS : " + accountlist.CustomerID);


        }
        public static void Login()
        {
            Console.WriteLine("Enter Your CustomerID");
            string customerid = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (AccountOpenning accountOpenning in accountopenningsList)
            {
                if (accountOpenning.CustomerID == customerid)
                {
                    check = true;
                    currentuser = accountOpenning;
                    Subamenu();
                    break;

                }
            }
            if (check == false)
            {
                Console.WriteLine("INVALID USERID!");
            }

        }
        public static void Subamenu()
        {
            string choice = "yes";
            do
            {
                Console.WriteLine("SUBMENU :");
                Console.WriteLine(" 1 . Depotit");
                Console.WriteLine(" 2 . Withdraw");
                Console.WriteLine(" 3 . Balance Check");
                Console.WriteLine(" 4 . Exit");
                Console.WriteLine("Please Select Option");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            Deposit();
                            break;
                        }
                    case "2":
                        {
                            Withdraw();
                            break;
                        }
                    case "3":
                        {
                            CurrentBalance();
                            break;
                        }
                    case "4":
                        {
                            choice = "no";
                            Console.WriteLine("You'r Selected Main Menu");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("INVALID OPTION PLEASE TRY AGAIN");
                            break;
                        }
                }
            } while (choice == "yes");
        }
        public static void Deposit()
        {
            double amount1;
            do
            {
                Console.WriteLine("Enter You'r Deposit Amount");
                string amount = Console.ReadLine().Trim();
                if (double.TryParse(amount, out amount1) && amount1 > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount Your Amount is Not Integer Is a Character Please Try Again");
                }
            } while (true);
            currentuser.Balance += amount1;
            Console.WriteLine("YOUR CURRENT BALANCE IS : " + currentuser.Balance);

        }
        public static void Withdraw()
        {
            double withdrawamount1;
            do
            {
                Console.WriteLine("Enter Amount To Withdraw");
                string withdrawamount = Console.ReadLine().Trim();
                if (double.TryParse(withdrawamount, out withdrawamount1) && withdrawamount1 > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Amount ");
                }
            } while (true);
            currentuser.Balance -= withdrawamount1;
            Console.WriteLine("YOU'R CURRENT BALANCE IS : " + currentuser.Balance);
        }
        public static void CurrentBalance()
        {
            Console.WriteLine("YOU'R CURRENT BALANCE : " + currentuser.Balance);
        }
        public static bool SpecialCharacter(string name)
        {

            foreach (char name1 in name)
            {
                if (!char.IsWhiteSpace(name1) && !char.IsLetter(name1))
                {
                    return true;
                }

            }
            return false;
        }
    }
}