using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class Subcategory
    {
        private static CultureInfo ci = new CultureInfo("en-us");
        
        private string _name;
        public string name { get { return _name; } set { _name = value; } }

        public Subcategory(string name)
        {
            string newCatName = ci.TextInfo.ToTitleCase(name.ToLower());
            this.name = newCatName;
        }
    }
}
