using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quotes.Models
{
    public class Quote
    {
        public int id { get; set; }
        public String author { get; set; }
        public String date { get; set; } 
        public String quote { get; set; }
        public int category { get; set; }

        public Quote() { }
        public Quote(int id, String author, String date, String quote, int category) {
            this.id = id;
            this.author = author;
            this.date = date;
            this.category = category;
            this.quote = quote;
        }

        public override string ToString()
        {
            return String.Format("id: {0}, author: {1}, date: {2} , categoty: {3}, quote: {4}", this.id, this.author, this.date, this.category, this.quote);
        }
    }
}