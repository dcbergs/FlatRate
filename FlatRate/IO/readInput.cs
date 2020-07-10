using System;
using System.Collections.Generic;
using System.Data;
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

        //gets the dataset passed in as parameter and adds/updates all the parts by ID to Parts table
        public void generatePartsList(DataSet data)
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
                    //find name, description, and price rows
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

                    if (idIndex < 0 || descIndex < 0 || priceIndex < 0)
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
                        else if (currentRow[descIndex] == "")
                        {
                            Console.WriteLine("blank description");
                        }
                        else if (currentRow[priceIndex] == "")
                        {
                            Console.WriteLine("blank price");
                        }
                        else
                        {
                            //add error condition for improperly formatted prices?
                            //if it doesn't contain ID already,
                            if (data.Tables["Parts"].Rows.Find(currentRow[idIndex]) == null)
                            {
                                DataRow newPart = data.Tables["Parts"].NewRow();
                                newPart["ID"] = currentRow[idIndex];
                                newPart["Description"] = currentRow[descIndex];
                                newPart["UnitPrice"] = float.Parse(currentRow[priceIndex], System.Globalization.CultureInfo.InvariantCulture);
                                data.Tables["Parts"].Rows.Add(newPart);
                            }
                            else
                            {
                                DataRow row = data.Tables["Parts"].Rows.Find(currentRow[idIndex]);
                                row["Description"] = currentRow[descIndex];
                                row["UnitPrice"] = float.Parse(currentRow[priceIndex], System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }

                    }
                    catch (MalformedLineException exc)
                    {
                        //message box
                        Console.WriteLine("Line " + exc + " is invalid.");
                    }
                }
            }

        }

    }
}