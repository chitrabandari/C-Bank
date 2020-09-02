using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BMS
{
    public class Customer
    {
        private int _acno;
        private string _name;
        private int _deposit;
        private char _type;
        private string _phoneno;

        public int useracno
        {
            get { return this._acno; }
            set { this._acno = value; }
        }
        public string username
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public string userphone
        {
            get { return this._phoneno; }
            set { this._phoneno = value; }
        }
        public char accttyp
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public int amount
        {
            get { return this._deposit; }
            set { this._deposit = value; }
        }
        public Customer(int acno, string name, string phoneno, char type, int deposit)
        {
            this._acno = acno;
            this._name = name;
            this._phoneno = phoneno;
            this._type = type;
            this._deposit = deposit;

        }

        public Customer()
        {
        }
        //SqlConnection con = null;
        //SqlCommand cmd = null;

        /*public SqlConnection EstablishConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }*/

        public void Create_account()
        {

            /* bool successflag = false;
             con = EstablishConnection();
             cmd = new SqlCommand("INSERT INTO CUSTOMER VALUES(" + useracno + " " + _name + " " + _phoneno + " " + _type + " " + _deposit + ")", con);
             con.Open();
             int count = cmd.ExecuteNonQuery();
             if (count > 0)
             {
                 successflag = true;
                 return successflag;
             }
             else
             {
                 return false;
             }*/


            Console.Write("\n Enter Account No : ");
            useracno = int.Parse(Console.ReadLine());
            Console.Write("\n Enter the Name of the Account Holder : ");
            _name = Console.ReadLine();
            Console.Write("\n Enter phone number:");
            _phoneno = Console.ReadLine();
            Console.Write("\n Enter the Type of the Account (c/s) : ");
            _type = char.Parse(Console.ReadLine());
            Console.Write("\n Enter the Initial Amount ");
            _deposit = int.Parse(Console.ReadLine());
            try
            {
                if (_type == 'c')
                {
                    if (_deposit < 2000)
                    {

                        Console.WriteLine("\nMinimum amount should be greater than 2000");
                    }

                    else
                    {
                        //deposit = int.Parse(Console.ReadLine());
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            // Console.Write("\n\n\n\t\t\t *ACCOUNT CREATED*  ");

            string cs = "Data Source=DESKTOP-QRCK471\\SQLEXPRESS ;Initial Catalog=BMS1;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO CUSTOMER VALUES(@acno,@name,@phoneno,@actype,@ini_amount)", con);

            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = useracno;

            cmd.Parameters.Add("@name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = _name;

            cmd.Parameters.Add("@phoneno", SqlDbType.VarChar);
            cmd.Parameters["@phoneno"].Value = _phoneno;

            cmd.Parameters.Add("@actype", SqlDbType.Char);
            cmd.Parameters["@actype"].Value = _type;

            cmd.Parameters.Add("@ini_amount", SqlDbType.Money);
            cmd.Parameters["@ini_amount"].Value = _deposit;


            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("account created successfully");
            }
            else
            {
                Console.WriteLine("unsucessfull");
            }
            con.Close();
            Console.ReadLine();

            //showAccount();

        }
        public void createaccount()
        {
            Create_account();
        }
        protected void show_Account()
        {
            //Console.WriteLine(customerList);
            Console.WriteLine("\n------------------------------------");
            Console.Write("\n Account no :{0} ", useracno);
            Console.Write("\n Account Holder Name :{0} ", _name);
            Console.Write("\n Phone number:{0} ", _phoneno);
            Console.Write("\n Type of Account :{0} ", _type);
            Console.Write("\n Balance Ammount :{0} ", _deposit);
            Console.WriteLine("\n-------------------------------------");


        }
        public void showAccount()
        {
            show_Account();
        }
        internal void modifyaccount()
        {
            //Console.Write("\n Account No : {0} ", _acno);
            Console.Write("\n\n Enter the account no :");
            useracno = int.Parse(Console.ReadLine());
            Console.Write("\n Update Account Holder Name : ");
            _name = Console.ReadLine();
            Console.Write("\n Update phone no: ");
            _phoneno = Console.ReadLine();

            string cs = "Data Source = DESKTOP-QRCK471\\SQLEXPRESS ;Initial Catalog=BMS1;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("update Customer set name=@name,phoneno=@phoneno where acno=@acno;", con);


            cmd.Parameters.Add("@acno", SqlDbType.Int);
            cmd.Parameters["@acno"].Value = useracno;

            cmd.Parameters.Add("@name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = _name;

            cmd.Parameters.Add("@phoneno", SqlDbType.VarChar);
            cmd.Parameters["@phoneno"].Value = _phoneno;

            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("account modified successfully");
            }
            else
            {
                Console.WriteLine("unsucessfull");
            }
            con.Close();
            Console.ReadLine();

            //Console.Write("\n\n\t\t\t *Account Modified Successfully* ");
            //Console.Write("Modify Balance Amount : ");
            //deposit = int.Parse(Console.ReadLine());
            showAccount();
        }
        public void modify_account()
        {
            modifyaccount();
        }
        public void CustomerList()
        {
            /* Customer c1 = new Customer(120, "mani", "7995456875", 'c', 1000);
             Customer c2 = new Customer(121, "nishitha", "9456123789", 's', 2000);
             Customer c3 = new Customer(122, "reethu", "9908473263", 's', 1500);
             Customer c4 = new Customer(123, "chitra", "9100531489", 's', 3000);

             List<Customer> list = new List<Customer>();
             list.Add(c1);
             list.Add(c2);
             list.Add(c3);
             list.Add(c4);

             foreach (Customer e in list)
             {
                 Console.WriteLine("\nAccount number ={0}, Name of customer= {1}, Phone number= {2}, Account Type= {3} ,Balance ={4}", e.useracno, e.username, e.userphone, e.accttyp, e.amount);
             }*/

            /*bool successflag = false;
            con = EstablishConnection();
            cmd = new SqlCommand("SELECT * FROM CUSTOMER",con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                Console.WriteLine(rdr[0] + "  " + rdr[1] + "  " + rdr[2] + "  " + rdr[3]+"  "+rdr[4]);
                successflag = true;

            }
            con.Close();
            return successflag;
            Console.ReadLine();*/



            string cs1 = "Data Source = DESKTOP-QRCK471\\SQLEXPRESS;Initial Catalog=BMS1;Integrated Security=True;";

            SqlConnection con = new SqlConnection(cs1);

            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + "   " + rdr[1] + "     " + rdr[2] + "  " + rdr[3] + " " + rdr[4]);
            }
            Console.ReadLine();
            con.Close();


        }

        public void customer_list()
        {
            CustomerList();
        }
        /*public void Create_account()
        {
            string cs = "Data Source=CHITRA\\SQLEXPRESS1 ;Initial Catalog=BMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO CUSTOMER(NAME,PHONENO,ACTTYPE,AMOUNT) VALUES(@0,@1,@2,@3,//@4)",con);
            con.Open();
            int count=cmd.ExecuteNonQuery();
            if(count>0)
            {
                Console.WriteLine("account created successfully");
            }
            else
            {
                Console.WriteLine("unsucessfull");
            }
            con.Close();
            Console.ReadLine();

        }
        public void show_Account()
        {

        }*/


    }
}