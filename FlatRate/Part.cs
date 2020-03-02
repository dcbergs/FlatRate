using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class Part
    {
        public String _partID;
        public String partID { get { return _partID; } set { _partID = value; } }

        public String _description;
        public String description { get { return _description; } set { _description = value; } }

        public float _price;
        public float price { get { return _price; } set { _price = value;} }

        public Part(String partTxt, String descriptionTxt, float priceAmt)
        {
            partID = partTxt;
            description = descriptionTxt;
            price = priceAmt;
        }
    }
}
