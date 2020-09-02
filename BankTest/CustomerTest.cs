using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


    namespace BMS.Tests
{

        
        public class CustomerTest
        {
            //Customer c1 = new Customer(123, "chitra", "9100531489", 's', 3000);
            
            public void CustomerList_match()
            {
                Customer cust = new Customer(123, "chitra", "9100531489", 's', 3000);
                int output = cust.useracno;

                Assert.AreEqual(output, 123);
                //Assert.AreEqual("chitra", c1.useracno);
            }


        }


    }


