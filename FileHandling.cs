using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("BankAccountOpening"))
            {
                Console.WriteLine("creating folder....");
                Directory.CreateDirectory("BankAccountOpening");
            }
            else
            {
                Console.WriteLine("Folder already exist..");
            }
            if (!File.Exists("BankAccountOpening/AccountOpening.csv"))
            {
                Console.WriteLine("creating file...");
                File.Create("BankAccountOpening/AccountOpening.csv").Close();
            }

        }
        public static void WriteCSVfile()
        {
            string[] array = new string[Program.accountopenningsList.Count];
            for (int i = 0; i < Program.accountopenningsList.Count; i++)
            {
                array[i] = Program.accountopenningsList[i].CustomerID + "," + Program.accountopenningsList[i].CustomerName + "," + Program.accountopenningsList[i].Balance + "," + Program.accountopenningsList[i].Gender + "," + Program.accountopenningsList[i].PhoneNumber + "," + Program.accountopenningsList[i].MailID + "," + Program.accountopenningsList[i].DateOfBirth.ToString("dd/MM/yyyy");
            }
            File.WriteAllLines("BankAccountOpening/AccountOpening.csv", array);
        }
        public static void ReadCSVfile()
        {
            string[] account = File.ReadAllLines("BankAccountOpening/AccountOpening.csv");
            foreach (string val in account)
            {
                AccountOpenning account1 = new AccountOpenning(val);
                Program.accountopenningsList.Add(account1);
            }
        }
    }
}