using FlatRate.Model;
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
        private static DataManager DataManager = DataManager.GetInstance();
        public static void Export(String filepath)
        {
            //open file
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine("ID,Title,Standard Price,");
                foreach(TaskSummary task in DataManager.GetTaskSummaries())
                {
                    String sanitizedId = SanitizedString(task.Id);
                    String sanitizedTitle = SanitizedString(task.Title);
                    String sanitizedPrice = SanitizedString(task.StandardTotal.ToString());
                    sw.WriteLine(sanitizedId + "," + sanitizedTitle + "," + sanitizedPrice + ",");
                }
            }
        }

        private static String SanitizedString(String input)
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
