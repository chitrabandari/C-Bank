using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BMS
{
    public class Accounts
    {
        public Accounts(float balance)
        {
            this.balance = balance;

        }

        public Accounts()
        {
        }

        public float balance;
        public int acno;
        Customer banks = new Customer();


        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }
        //public void Deposit(int acno,float amount)
        /*{
            con = EstablishConnection();
            cmd= new SqlCommand("UPDATE")

        }*/


        public void Deposit()
        {

            float amount;
            //Console.Write(" Enter Account No to which U want to Deposit ");
            Console.Write("\nEnter the account no you want to deposit:");
            acno = int.Parse(Console.ReadLine());


            Console.Write("\n Enter the Amount u want to Deposit : ");
            amount = float.Parse(Console.ReadLine());
            /*if (amount >= 0)
            {
                balance += amount;
                Console.Write("\n\n\t\t\t Amount Deposited Successfully of Rupees = " + amount);
                //return balance;
                Console.Write("\n Your balance is : " + balance);
            }
            else
            {
                Console.Write("\n\n\t\t\t Deposited amount shound be > 0  ");

            }*/

            Customer c = new Customer();

            string cs1 = "Data Source = DESKTOP-QRCK471\\SQLEXPRESS; Initial Catalog=BMS1; Integrated Security=True;";

            SqlConnection con = new SqlConnection(cs1);
            SqlCommand cmd = new SqlCommand(" UPDATE Account SET balance=@balance + @amount where acno=@acno;", con);

            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = acno;

            cmd.Parameters.Add("@amount", SqlDbType.Money);
            cmd.Parameters["@amount"].Value = amount;

            //cmd.Parameters.Add("@ini_amount", SqlDbType.Money);
            //cmd.Parameters["@ini_amount"].Value = c.amount_deposit;


            cmd.Parameters.Add("@balance", SqlDbType.Money);
            cmd.Parameters["@balance"].Value = balance;



            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("deposited successfully!!");
            }
            else
            {
                Console.WriteLine("unsucessful!!");
            }
        }


        /*public void Deposit(int acno,float amount)
        {
            string cs1 = "Data Source=CHITRA\\SQLEXPRESS1 ;Initial Catalog=BMS1;Integrated Security=True;";

            SqlConnection con = new SqlConnection(cs1);
            SqlCommand cmd = new SqlCommand(" UPDATE ACCOUNT SET balance=@balance+@amount where acno=@acno;", con);

            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = acno;

            cmd.Parameters.Add("@amount", SqlDbType.Money);
            cmd.Parameters["@amount"].Value = amount;

            //cmd.Parameters.Add("@amount", SqlDbType.Money);
            //cmd.Parameters["@amount"].Value = amount;

            cmd.Parameters.Add("@balance", SqlDbType.Money);
            cmd.Parameters["@balance"].Value = balance;
           


            con.Open();
            int count=cmd.ExecuteNonQuery();
            if(count>0)
            {
                Console.WriteLine(" successully");

            }
            else
            {
                Console.WriteLine("false");
            }
        }*/
        public void Withdraw()
        {

            float amount;
            Console.Write("\nEnter the account no you want to deposit:");
            acno = int.Parse(Console.ReadLine());

            Console.Write("\n Enter the Amount u want to Withdraw : ");
            amount = float.Parse(Console.ReadLine());

            /* if (amount > (balance - 500))
             {
                 Console.WriteLine("\n Insuficient Balance (Minium Bal in account should be 500) draw <=500 ");
             }
             else
             {
                 //Console.WriteLine("\n YOUR CURRENT BALANCE IS {0}", balance);
                 this.balance -= amount;
                 Console.Write("\n\n\t\t\t Amount Withdrawn Successfully of Rupees = " + amount);
             }*/

            string cs1 = "Data Source = DESKTOP-QRCK471\\SQLEXPRESS ;Initial Catalog=BMS1;Integrated Security=True;";

            SqlConnection con = new SqlConnection(cs1);
            SqlCommand cmd = new SqlCommand(" UPDATE ACCOUNT SET balance=@balance-@amount where acno=@acno;", con);

            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = acno;

            cmd.Parameters.Add("@amount", SqlDbType.Money);
            cmd.Parameters["@amount"].Value = amount;

            /*cmd.Parameters.Add("@amount", SqlDbType.Money);
            cmd.Parameters["@amount"].Value = amount;*/

            cmd.Parameters.Add("@balance", SqlDbType.Money);
            cmd.Parameters["@balance"].Value = balance;



            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("withdraw successfull!!");

            }
            else
            {
                Console.WriteLine("false");
            }
        }


        /*public void Transfer()
        {
            int destAccount; 
            float amount;
            Console.Write("\n Enter the destination account no : ");
            destAccount = int.Parse(Console.ReadLine());
            Console.Write("\n Enter the amount u want to transfer : ");
            amount = float.Parse(Console.ReadLine());
            this.balance += amount;
            //destAccount.Deposit();
            //this.Withdraw();
        }*/

        public void GetBalance()
        {
            //Console.Write("\n \n Balance ::{0}\n ", balance);
            //Console.Write("\n Acno ::{0} \n Balance ::{4}\n ", acno, balance);
            Console.WriteLine("enter acno to get balance:");
            acno = int.Parse(Console.ReadLine());

            string cs = "Data Source = DESKTOP-QRCK471\\SQLEXPRESS; Initial Catalog=BMS1; Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select acno,balance from Account where acno = @acno", con);

            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = acno;

            con.Open();
            /*int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("unsucessfull");
            }
            con.Close();
            Console.ReadLine();*/

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("account no : " + rdr[0] + " balance: " + rdr[1], con);
            }
            Console.ReadLine();
            con.Close();

        }
    }
}