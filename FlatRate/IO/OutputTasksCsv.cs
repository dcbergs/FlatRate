using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.IO
{
    class OutputTasksCsv
    {
        public static void export(DataSet data, String filepath)
        {
            //query for id, title, and standard price
            var taskrows =
                (from task in data.Tables["Tasks"].AsEnumerable()
                 join taskpart in data.Tables["Tasks_Parts"].AsEnumerable()
                 on task.Field<String>("ID") equals taskpart.Field<String>("TaskID") into tp
                 select new
                 {
                     id = task.Field<String>("ID"),
                     title = task.Field<String>("Title"),
                     stdtotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.STANDARD_RATE) + task.Field<float>("StdAddOn")),
                 }).ToList();

            //open file
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine("ID,Title,Standard Price,");
                foreach(var task in taskrows)
                {
                    String sanitizedId = sanitizedString(task.id);
                    String sanitizedTitle = sanitizedString(task.title);
                    String sanitizedPrice = sanitizedString(task.stdtotal.ToString());
                    sw.WriteLine(sanitizedId + "," + sanitizedTitle + "," + sanitizedPrice + ",");
                }
            }
        }

        private static String sanitizedString(String input)
        {
            if(input.Contains('"') || input.Contains(','))
            {
                input = input.Replace("\"", "\"\"");
                input = "\"" + input + "\"";
            }
            return input;
        }
    }
}
