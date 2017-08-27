using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quotes.Models
{
    public class Category
    {
        private int _id;
        public int id { get { return _id; } }
        public String name { get; set; }

        public Category(int id, String name) {
            this._id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return String.Format("id: {0}, name: {1}", this.id, this.name);
        }

    }
}