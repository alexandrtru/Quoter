using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Quotes.DAL;
using Quotes.Models;

namespace Quotes.Tests
{
    [TestClass]
    public class DALUpdatingTest
    {
        [TestMethod]
        public void updateCategory() {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.updateCategory(new Category(5,"Sciense")));
        }

        [TestMethod]
        public void updateQuote()
        {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.updateQuote(new Quote(6,"Pushkin", DateTime.Now.ToLongDateString(), "ya vas lybil", 5)));
    }
}
}
