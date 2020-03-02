using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class Category
    {
        private static CultureInfo ci = new CultureInfo("en-us");
        private string _categoryName;
        public string categoryName { get { return _categoryName; } set { _categoryName = value; } }

        private HashSet<string> _subcategories;
        public HashSet<string> subcategories { get { return _subcategories; } }

        public Category(string name)
        {
            string newCatName = ci.TextInfo.ToTitleCase(name.ToLower());
            categoryName = newCatName;
            _subcategories = new HashSet<string>();
        }

        public void addSubcategory(string name)
        {
            //convert to title case

            if (!subcategories.Contains(name))
            {
                subcategories.Add(name);
            }
        }

    }
}
