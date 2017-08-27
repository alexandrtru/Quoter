using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Quotes.Models;

namespace Quotes.DAL
{
    public class DataAccessLayer
    {
        SqlConnection connection;

        public DataAccessLayer() {
            connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\base.mdf; Integrated Security = True"); 
        }

        //C
        public Category createCategory(String name)
        {
            String queryString = String.Format("INSERT INTO Categories VALUES (N'{0}'); Select SCOPE_IDENTITY()", name);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            int freshId = Convert.ToInt32(query.ExecuteScalar());
            connection.Close();

            return new Category(freshId, name);
        }

        public void createQuote(Quote q)
        {
            String queryString = String.Format("INSERT INTO Quotes VALUES (N'{0}', GETDATE(), N'{1}', {2}); SELECT SCOPE_IDENTITY()", q.author, q.quote, q.category);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            try
            {
                query.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            connection.Close();
        }

        //R
        public List<Category> getAllCategories() {
            List<Category> result = new List<Category>();

            SqlCommand query = new SqlCommand("Select * from Categories", connection);
            connection.Open();
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Category(reader.GetInt32(0), reader.GetString(1)));
            }
            reader.Close();
            connection.Close();

            return result;
        }

        public List<Quote> getAllQuotes() {
            List<Quote> result = new List<Quote>();

            SqlCommand query = new SqlCommand("Select * from Quotes", connection);
            connection.Open();
            SqlDataReader reader =  query.ExecuteReader();
            while (reader.Read()) {
                result.Add(new Quote(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2).ToLongDateString(), reader.GetString(3), reader.GetInt32(4)));
            }
            reader.Close();
            connection.Close();

            return result;
        }
        
        public Quote getSingleQuote(int id) {
            String queryString = String.Format("Select * from Quotes where id = {0}", id);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            Quote result = new Quote(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2).ToLongDateString(), reader.GetString(3), reader.GetInt32(4));
            reader.Close();
            connection.Close();

            return result;
        }

        //U 
        public bool updateCategory(Category cat) {
            String queryString = String.Format("UPDATE Categories SET name = N'{0}' WHERE id = {1};", cat.name, cat.id);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            try
            {
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                connection.Close();
                return false;
            }
        }

        public bool updateQuote(Quote q) {
            String queryString = String.Format("UPDATE Quotes SET author = N'{0}', quote = N'{1}', category = {2} WHERE id = {3};", q.author, q.quote, q.category, q.id);
            SqlCommand query = new SqlCommand(queryString, connection);
            System.Diagnostics.Debug.WriteLine(q.ToString());
            connection.Open();
            try
            {
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                connection.Close();
                return false;
            }
        }

        //D
        public bool deleteCategory(int cat) {
            String queryString = String.Format("DELETE FROM Categories WHERE id = {0}", cat);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            try
            {
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                connection.Close();
                return false;
            }
        }

        public bool deleteQuote(int qId)
        {
            String queryString = String.Format("DELETE FROM Quotes WHERE id = {0}", qId);
            SqlCommand query = new SqlCommand(queryString, connection);
            connection.Open();
            try
            {
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                connection.Close();
                return false;
            }
        }

        //Filters

        public List<Quote> getFilteredQuotes(string author, int category)
        {
            List<Quote> result = new List<Quote>();

            String query = "Select * from Quotes";
            if (!author.Equals("") & category != 0)
            {
                query += String.Format("  where author like N'{0}%' AND category = {1}", author, category);
            }
            else
            {
                if (!author.Equals("")) query += String.Format(" where author like N'{0}%' ", author);
                if (category != 0) query += String.Format(" where category = '{0}' ", category);
            }
            query += ';';
            System.Diagnostics.Debug.WriteLine(query);
            SqlCommand querySql = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = querySql.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Quote(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2).ToLongDateString(), reader.GetString(3), reader.GetInt32(4)));
            }
            reader.Close();
            connection.Close();

            return result;
        }
    }
}