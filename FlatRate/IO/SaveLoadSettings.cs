using System;
using System.IO;
using System.Linq;

namespace FlatRate
{
    class SaveLoadSettings
    {
        private string filename;
        public string DataFilename { get; private set; }

        public SaveLoadSettings()
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FlatRate");
            Directory.CreateDirectory(filename);
            DataFilename = "";
        }

        public void saveRates()
        {
            string[] lines = { "Standard Rate: ", Program.STANDARD_RATE.ToString(), "Premium Rate: ", Program.PREMIUM_RATE.ToString() };
            File.WriteAllLines(Path.Combine(filename, "rates.txt"), lines);
        }

        public void loadRates()
        {
            //set rates to negative so it can detect if they are not read
            Program.STANDARD_RATE = -1.0f;
            Program.PREMIUM_RATE = -1.0f;
            string inputLine;
            if(File.Exists(Path.Combine(filename, "rates.txt")))
            {
                StreamReader file = new StreamReader(Path.Combine(filename, "rates.txt"));
                while ((inputLine = file.ReadLine()) != null)
                {
                    if (inputLine == "Standard Rate: ")
                    {
                        //next line should be standard rate
                        inputLine = file.ReadLine();
                        float.TryParse(inputLine, out Program.STANDARD_RATE);
                        if (Program.STANDARD_RATE < 0)
                        {
                            file.Close();
                            throw new Exception();
                        }
                    }
                    else if (inputLine == "Premium Rate: ")
                    {
                        //next line should be premium rate
                        inputLine = file.ReadLine();
                        float.TryParse(inputLine, out Program.PREMIUM_RATE);
                        if (Program.PREMIUM_RATE < 0)
                        {
                            file.Close();
                            throw new Exception();
                        }
                    }
                }
                file.Close();
            }
            //if there is no file at all
            else
            {
                Program.STANDARD_RATE = 160.0f;
                Program.PREMIUM_RATE = 180.0f;
            }
        }

        public void saveMostRecent(string path)
        {
            string[] lines = { "Previous file loaded: ", path };
            File.WriteAllLines(Path.Combine(filename, "previous.txt"), lines);
        }

        public string loadMostRecent()
        {
            string previousFilePath = "";
            string inputLine;
            if (File.Exists(Path.Combine(filename, "previous.txt")))
            {
                StreamReader settingFile = new StreamReader(Path.Combine(filename, "previous.txt"));
                while ((inputLine = settingFile.ReadLine()) != null)
                {
                    if (inputLine == "Previous file loaded: ")
                    {
                        //next line should be file path
                        previousFilePath = settingFile.ReadLine();
                        DataFilename = previousFilePath.Split('\\').Last();
                    }
                }
                settingFile.Close();
            }
            //if the conditions are not met, returns an empty string
            return previousFilePath;
        }

    }
}
