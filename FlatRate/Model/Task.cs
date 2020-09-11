using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.Model
{
    class Task
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public float Hours { get; set; }
        public float StandardAddOn { get; set; }
        public float PremiumAddOn { get; set; }

    }
}
