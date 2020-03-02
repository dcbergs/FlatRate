using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace FlatRate
{
    class readInput
    {
        private String filename;

        //set filename
        public readInput(String filename)
        {
            this.filename = filename;
        }

        //takes a PartList object (may be empty) and generates a new PartList with added parts from filename stored in readInput object
        public PartList generatePartsList(PartList partList)
        {
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] currentRow;

                //keep track of which column holds which information
                int idIndex = -1;
                int descIndex = -1;
                int priceIndex = -1;

                //before looping through whole table, see if the first row has header data
                try
                {
                    //find name, description, category, subcategory, and price rows
                    currentRow = parser.ReadFields();
                    for (int i = 0; i < currentRow.Length; i++)
                    {
                        if (String.Equals(currentRow[i], "name", StringComparison.OrdinalIgnoreCase))
                        {
                            idIndex = i;
                        }
                        else if (String.Equals(currentRow[i], "description", StringComparison.OrdinalIgnoreCase))
                        {
                            descIndex = i;
                        }
                        else if (String.Equals(currentRow[i], "unitprice", StringComparison.OrdinalIgnoreCase))
                        {
                            priceIndex = i;
                        }
                    }

                    if(idIndex < 0 || descIndex < 0 || priceIndex < 0)
                    {
                        Console.WriteLine("error reading columns");
                        //message box
                        //error reading columns! make sure data contains a "name", "description", and "unitprice" column
                    }


                }
                catch (MalformedLineException exc)
                {
                    //message box
                    Console.WriteLine("Line " + exc + " is invalid.");
                } 

                //parse through rest of input
                while (!parser.EndOfData)
                {
                    try
                    {
                        currentRow = parser.ReadFields();

                        //TODO if only some are missing, indicate that data is missing
                        //TextFieldParser gives blanks as "" apparently, not null
                        if (currentRow[idIndex] == "")
                        {
                            //notify that some data was missing for these conditions
                            Console.WriteLine("blank name");
                        }
                        else if(currentRow[descIndex] == "")
                        {
                            Console.WriteLine("blank description");
                        }
                        else if(currentRow[priceIndex] == "")
                        {
                            Console.WriteLine("blank price");
                        }
                        else
                        {
                            //add error condition for improperly formatted prices?
                            Part newPart = new Part(currentRow[idIndex], currentRow[descIndex], float.Parse(currentRow[priceIndex], System.Globalization.CultureInfo.InvariantCulture));
                            partList.addPart(newPart);
                        }
                        
                    }
                    catch(MalformedLineException exc)
                    {
                        //message box
                        Console.WriteLine("Line " + exc + " is invalid.");
                    }
                }
            }

            return partList;
        }

        //loads task list from csv, takes as a parameter the current category list
        //which will be updated to match the categories found in csv
        public List<Task> loadTaskList(Dictionary<string, Category> categories)
        {
            List<Task> taskList = new List<Task>();
            categories.Clear();

            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] currentRow;

                //keep track of which columns hold which information
                int taskIDCol = -1;
                int taskTitleCol = -1;
                int taskDescriptionCol = -1;
                int taskCategoryCol = -1;
                int taskSubCatCol = -1;
                int taskHoursCol = -1;
                //other columns are determined by part info
                int partNameCol = -1;
                int partDescriptionCol = -1;
                int partUnitCostCol = -1;
                int partQuantityCol = -1;

                currentRow = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    //current row is first row on first iteration (called before while loop), otherwise it has already been called at the end
                    //where it was determined that a new task had started

                    try
                    {
                        //case where row is task headers, followed by task info
                        //FIRST COLUMN MUST BE "taskID", REST MAY BE ANY SPACING/ORDER
                        if (String.Equals(currentRow[0], "taskID", StringComparison.OrdinalIgnoreCase))
                        {
                            taskIDCol = 0;

                            for(int i = 1; i < currentRow.Length; i++)
                            {
                                if (String.Equals(currentRow[i], "title", StringComparison.OrdinalIgnoreCase))
                                {
                                    taskTitleCol = i;
                                }
                                else if (String.Equals(currentRow[i], "description", StringComparison.OrdinalIgnoreCase))
                                {
                                    taskDescriptionCol = i;
                                }
                                else if (String.Equals(currentRow[i], "category", StringComparison.OrdinalIgnoreCase))
                                {
                                    taskCategoryCol = i;
                                }
                                else if (String.Equals(currentRow[i], "subcategory", StringComparison.OrdinalIgnoreCase))
                                {
                                    taskSubCatCol = i;
                                }
                                else if (String.Equals(currentRow[i], "hours", StringComparison.OrdinalIgnoreCase))
                                {
                                    taskHoursCol = i;
                                }
                            }
                            if(taskTitleCol < 0 || taskDescriptionCol < 0 || taskCategoryCol < 0 || taskSubCatCol < 0 || taskHoursCol < 0)
                            {
                                //could not find one of the columns!
                            }

                            //if we're here, get the next row which should be task info
                            currentRow = parser.ReadFields();
                            Task newTask = new Task();
                            if(currentRow[taskIDCol] == "" || currentRow[taskTitleCol] == "" || 
                                currentRow[taskDescriptionCol] == "" || currentRow[taskCategoryCol] == "" || 
                                currentRow[taskHoursCol] == "")
                            {
                                //we had blank info within a job
                                //excludes subcat which is allowed to be blank
                            }
                            else
                            {
                                float output;
                                if(float.TryParse(currentRow[taskHoursCol], out output))
                                {
                                    newTask.taskID = currentRow[taskIDCol];
                                    newTask.title = currentRow[taskTitleCol];
                                    newTask.description = currentRow[taskDescriptionCol];
                                    Category tempCat = new Category(currentRow[taskCategoryCol]);
                                    Subcategory tempSub = new Subcategory(currentRow[taskSubCatCol]);
                                    tempCat.addSubcategory(tempSub.name);
                                    newTask.subcategory = tempSub;

                                    newTask.category = tempCat;
                                    if (!categories.ContainsKey(tempCat.categoryName))
                                    {
                                        categories.Add(tempCat.categoryName, tempCat);
                                    }
                                    newTask.hours = output;
                                }
                                else
                                {
                                    //problem converting hours from string
                                }
                            }

                            //make sure next row is headers for parts
                            currentRow = parser.ReadFields();
                            for (int i = 0; i < currentRow.Length; i++)
                            {
                                if (String.Equals(currentRow[i], "partName", StringComparison.OrdinalIgnoreCase))
                                {
                                    partNameCol = i;
                                }
                                else if (String.Equals(currentRow[i], "partDescription", StringComparison.OrdinalIgnoreCase))
                                {
                                    partDescriptionCol = i;
                                }
                                else if (String.Equals(currentRow[i], "partUnitCost", StringComparison.OrdinalIgnoreCase))
                                {
                                    partUnitCostCol = i;
                                }
                                else if (String.Equals(currentRow[i], "partQuantity", StringComparison.OrdinalIgnoreCase))
                                {
                                    partQuantityCol = i;
                                }
                            }
                            if(partNameCol < 0 || partDescriptionCol < 0 || partUnitCostCol < 0 || partQuantityCol < 0)
                            {
                                //couldn't find part information columns!
                            }
                            else
                            {
                                //iterate through rows until finding a blank row or another job info heading row
                                bool moreParts = true;
                                while (moreParts)
                                {
                                    currentRow = parser.ReadFields();
                                    if (currentRow == null)
                                    {
                                        //previous part was last row
                                        moreParts = false;
                                    }

                                    //if all fields missing (fully blank line), part data is over
                                    bool allBlank = true;
                                    if (moreParts)
                                    {
                                        foreach (string entry in currentRow)
                                        {
                                            if (entry != "")
                                            {
                                                allBlank = false;
                                            }
                                        }
                                    }
                                    
                                    if (allBlank)
                                    {
                                        moreParts = false;
                                    }
                                    //if fields match task headings, stop
                                    if (moreParts)
                                    {
                                        for (int i = 0; i < currentRow.Length; i++)
                                        {
                                            if (String.Equals(currentRow[i], "taskID", StringComparison.OrdinalIgnoreCase) ||
                                                String.Equals(currentRow[i], "title", StringComparison.OrdinalIgnoreCase) ||
                                                String.Equals(currentRow[i], "description", StringComparison.OrdinalIgnoreCase) ||
                                                String.Equals(currentRow[i], "category", StringComparison.OrdinalIgnoreCase) ||
                                                String.Equals(currentRow[i], "subcategory", StringComparison.OrdinalIgnoreCase) ||
                                                String.Equals(currentRow[i], "hours", StringComparison.OrdinalIgnoreCase))
                                            {
                                                moreParts = false;
                                                //should jump right back to top, assess currentRow[0] == taskID, and continue
                                            }
                                        }
                                    }
                                    
                                    //add part to task
                                    if (moreParts)
                                    {
                                        float tryPrice;
                                        float tryQty;
                                        if (float.TryParse(currentRow[partUnitCostCol], out tryPrice) &&
                                            float.TryParse(currentRow[partQuantityCol], out tryQty))
                                        {
                                            TaskRow taskRow = new TaskRow(currentRow[partNameCol], currentRow[partDescriptionCol], tryPrice, tryQty);
                                            newTask.addComponent(taskRow);
                                        }
                                        else
                                        {
                                            //problem converting price or quantity from string
                                            Console.WriteLine("error converting part price or quantity");
                                        }
                                    }
                                }

                            }

                            //add task to task list
                            taskList.Add(newTask);
                            newTask = new Task();
                        }

                    }
                    catch (MalformedLineException e)
                    {
                        //error reading data
                        Console.WriteLine("Line " + e + " is invalid.");
                    }

                }

            }

            return taskList;
        }
    }
}
