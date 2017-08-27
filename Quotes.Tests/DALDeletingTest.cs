using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Quotes.DAL;
using Quotes.Models;

namespace Quotes.Tests
{
    [TestClass]
    public class DALDeletingTest
    {
        [TestMethod]
        public void deleteCategoty()
        {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.deleteCategory(new Category(5, "Sciense")));
        }

        [TestMethod]
        public void deleteQuote()
        {
            DataAccessLayer data = new DataAccessLayer();
            Debug.Write(data.deleteQuote(new Quote(3, "Pushkin", DateTime.Now.ToLongDateString(), "ya vas lybil", 5)));
        }
    }
}
