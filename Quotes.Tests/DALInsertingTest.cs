using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Quotes.DAL;
using Quotes.Models;

namespace Quotes.Tests
{
    [TestClass]
    public class DALInsertingTest
    {
        [TestMethod]
        public void insertCategory() {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.createCategory("Sciense").ToString());
        }

        [TestMethod]
        public void insertQuote()
        {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.createQuote("Tesla", "Tasdas", 5));
    }
}
}
