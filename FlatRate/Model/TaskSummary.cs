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
        private readonly String id;
        private readonly String title;
        private readonly String description;
        private readonly String categoryName;
        private readonly String subcategoryName;
        private readonly float hours;
        private readonly double standardTotal;
        private readonly double premiumTotal;

        public TaskSummary(
            String id,
            String title,
            String description,
            String categoryName,
            String subcategoryName,
            float hours,
            double standardTotal,
            double premiumTotal
            )
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.categoryName = categoryName;
            this.subcategoryName = subcategoryName;
            this.hours = hours;
            this.standardTotal = standardTotal;
            this.premiumTotal = premiumTotal;
        }

    }
}
