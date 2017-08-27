using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Quotes.Tests
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void TestConnect() {
            SqlConnection connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\user\\source\\repos\\Quotes\\Quotes\\App_Data\\base.mdf; Integrated Security = True");
            connection.Open();
            connection.Close();
        }
    }
}
