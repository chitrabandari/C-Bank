/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Bank
    {
        *//*private int acno;

        public int useracno
        {
            get { return acno; }
            set { acno = value; }
        }

        protected string name;
        public int mobile;
        internal float balance;
        protected internal char type;
        public string password;*//*

        public string name;

        private List<accounts> BankAccounts;
        public Bank(string name)
        {
            this.name = name;
            BankAccounts = new List<accounts>();
        }

        public int OpenBankAccount(int acno, String name, int mobile, Type accountType, float balance, string password)
        {
            Console.Write("\n Enter Account No : ");
            acno = int.Parse(Console.ReadLine());
            Console.Write("\n Enter the Name of the Account Holder : ");
            name = Console.ReadLine();
            Console.Write("\n Enter Mobile No : ");
            mobile = int.Parse(Console.ReadLine());
            Console.Write("\n Enter the Type of the Account (c/s) : ");
            //accountType = (Console.ReadLine());
            Console.Write("\n Enter the Initial or Minimum Amount (>=500 for savimgs and >=1000 for current) : ");
            balance = int.Parse(Console.ReadLine());
            Console.Write("\n Create a Password : ");
            password = Console.ReadLine();
            Console.Write("\n\n\n\t\t\t *****ACCOUNT CREATED SUCCESSFULLY*****  ");

            int newId = BankAccounts.Count();

            BankAccounts.Add((accounts)Activator.CreateInstance(accountType,newId, balance));

            return newId;
        }

        *//*public accounts GetAccount(int acno)
        {
            accounts account = BankAccounts.Where(x => x.owner == acno).FirstOrDefault();

            if (account == null)
            {
                throw new ApplicationException("no account exists with that id");
            }

            return account;
        }*//*
    }
}
*/