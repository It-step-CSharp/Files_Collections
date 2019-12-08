namespace Logger
{
    using System;
    using System.IO;

    public class DoorLogger
    {
        private string filePath;

        public DoorLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void LogEnter(string name)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath,true))
            {
                string logInfo = LogInfo(name, true);
                streamWriter.WriteLine(logInfo);
            }
        }

        public void LogExit(string name)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath,true))
            {
                string logInfo = LogInfo(name, false);
                streamWriter.WriteLine(logInfo);
            }
        }

        public void Report()
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void Report(string name)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;
                bool hasMatch = false;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string lineName = tokens[0];

                    if (name == lineName)
                    {
                        Console.WriteLine(line);
                        hasMatch = true;
                    }
                }

                if (!hasMatch)
                {
                    Console.WriteLine($"There is no information about {name}");
                }
            }
        }

        private string LogInfo(string name, bool isEnter)
        {
            return isEnter? 
                $"{name} entered the building at {DateTime.Now}":
                $"{name} exit the building at {DateTime.Now}";
        }
    }
}
