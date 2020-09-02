using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Program
    {

        Accounts bank = new Accounts(1000);
        Customer banks = new Customer();
        int num;

        static void Main(string[] args)
        {
            Program mainObj = new Program();
            mainObj.Login();
        }

        public void Login()
        {
            Console.Write("\n Enter Usename : \n");
            string username = Console.ReadLine();
            Console.Write("\n Enter Password : \n");
            string password = Console.ReadLine();

            if ((username.Equals("nishi")) && (password.Equals("chitra")))
            {
                Console.Write("\n You are Successfully Logged in ");
                MainMenu();
            }
            else
            {
                Console.Write("\n Invalid Username & Password");
            }
            
        }

        public void MainMenu()
        {
            Console.Write("\n\n\n\t\t\t\t\t BANK MANAGEMENT SYSTEM  ");
            Console.Write("\n\n\t\t =========================================================== ");

            Console.Write("\n\n\t01. Create New Account");
            Console.Write("\n\t02. Update Account Details");
            //Console.Write("\n\t03. View Account Details");
            Console.Write("\n\t03. List Customer Details");
            Console.Write("\n\t04. Deposit Amount");
            Console.Write("\n\t05. Withdraw Amount");
            Console.Write("\n\t06. Balance Enquiry");
            //Console.Write("\n\t08. Transfer Money");
            Console.Write("\n\t07. Exit");

            //Console.Write("\n\n Enter Your choice :  ");

            //option = Console.Read() ;
            MainMenuDetails();

        }

        private void MainMenuDetails()
        {
            Console.Write("\n\n Enter Your choice :  ");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Clear();
                        banks.createaccount();
                        MainMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        //Console.Write("\n\n Enter the account no :");
                        //num = int.Parse(Console.ReadLine());
                        banks.modifyaccount();
                        MainMenu();
                        break;
                    }

                case 3:
                    {
                        Console.Clear();
                        banks.CustomerList();
                        MainMenu();
                        break;
                    }

                case 4:
                    {
                        Console.Clear();
                        bank.Deposit();
                        MainMenu();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        bank.Withdraw();
                        MainMenu();
                        break;
                    }
                case 6:
                    {
                        Console.Clear();
                        bank.GetBalance();
                        MainMenu();
                        break;
                    }
                /*case 8:
                    {
                        Console.Clear();
                        bank.Transfer();
                        break;
                    }*/
                case 7:
                    {
                        break;
                    }
            }
        }
    }
}