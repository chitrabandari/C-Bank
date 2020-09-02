using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMS.Tests;

namespace BMS.Tests
{
    /// <summary>
    /// Summary description for accountsTest
    /// </summary>
    [TestClass]
    public class AccountsTests
    {
        
        [TestMethod]
        public void getbalance()
        {
            
            float expected = 77;
            Accounts account = new Accounts(1000);
            float output = account.balance;
            //account.Deposit();
            float actual = account.balance;
            Assert.AreEqual(expected, actual ,output);
            Assert.AreEqual(output, 1000);
        }


        /*public accounts(float balance)
        {
            this.balance = balance;
        }
        *//*public void Deposit()
        {

            this.balance += amount;
        }*//*
        public void getBalance()
        {
            accounts acc = new accounts(500);
            //acc.Deposit();
            //int expected = 150;
            float output = acc.balance;
            Assert.AreEqual(output, 500);

            //acc.Deposit();
            
            //Assert.AreEqual(500, balance);
        }
        *//*public void Withdraw()
        {
            this.balance -= amount;
        }*/
        /*public void TestCredit()
        {
            accounts acc = new accounts(150);
            //acc.Deposit();
            //acc.Withdraw();
            float output = acc.balance;
            Assert.AreEqual(150, balance);
        }*/
    }
}



