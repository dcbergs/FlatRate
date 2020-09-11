using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.Model
{
    /**
     * essentially a read DTO for tasks, gets basic info without details about specific parts
     * */
    class TaskSummary
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String CategoryName { get; set; }
        public String SubcategoryName { get; set; }
        public float Hours { get; set; }
        public double StandardTotal { get; set; }
        public double PremiumTotal { get; set; }

    }
}
