using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class OutputTasks
    {
        private System.IO.StreamWriter sw;
        public OutputTasks(System.IO.StreamWriter streamWriter)
        {
            sw = streamWriter;
        }

        //writes task list including parts to csv in special format
        public void writeTaskList(List<Task> taskList)
        {
            foreach(Task task in taskList)
            {
                //header for task
                sw.WriteLine("taskID,title,description,category,subcategory,hours,partsCost,standardTotal,premiumTotal");
                //basic task info
                sw.Write(task.taskID + "," + task.title + "," + task.description + ",");
                sw.Write(task.category.categoryName + "," + task.subcategory.name + ",");
                sw.WriteLine(task.hours + "," + task.partsCost + "," + task.standardTotal + "," + task.premiumTotal);

                //header for parts
                sw.WriteLine(",partName,partDescription,partUnitCost,partQuantity,partSubtotal");

                //parts/task row info
                foreach(TaskRow taskRow in task.taskParts)
                {
                    sw.Write("," + taskRow.partName + "," + taskRow.partDescription + "," + taskRow.partUnitCost);
                    sw.WriteLine("," + taskRow.partQuantity + "," + taskRow.partSubtotal);
                }

                //blank row between tasks
                sw.WriteLine("");
            }
        }
    }
}
