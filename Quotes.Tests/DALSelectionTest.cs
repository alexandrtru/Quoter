using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Quotes.DAL;
using Quotes.Models;
    
namespace Quotes.Tests
{
    [TestClass]
    public class DALSelectionTest
    {
        [TestMethod]
        public void SelectCategotiesTest()
        {
            DataAccessLayer DAO = new DataAccessLayer();
            foreach (Category cat in DAO.getAllCategories())
            {
                Debug.Write(cat.ToString());
            };
        }

        [TestMethod]
        public void SelectQuotesTest()
        {
            DataAccessLayer DAO = new DataAccessLayer();
            foreach (Quote q in DAO.getAllQuotes())
            { 
                Debug.Write(q);
            };
        }
    }
}
