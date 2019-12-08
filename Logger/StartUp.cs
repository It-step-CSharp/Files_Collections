namespace Logger
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static Dictionary<string, bool> personList = new Dictionary<string, bool>();

        static void Main(string[] args)
        {
            DoorLogger logger = new DoorLogger("logger.txt");
            StartLogger(logger);
        }

        static void StartLogger(DoorLogger logger)
        {
            while (true)
            {
                Console.Write("Please enter your name: ");
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    return;
                }

                if (command.ToLower() == "report")
                {
                    Console.Write("All/{name}: ");
                    string reportCommand = Console.ReadLine();
                    if (reportCommand.ToLower() == "all")
                    {
                        logger.Report();
                    }
                    else
                    {
                        logger.Report(reportCommand);
                    }
                }

                if (!personList.ContainsKey(command))
                {
                    personList[command] = false;
                }

                if (!personList[command])
                {
                    logger.LogEnter(command);
                    personList[command] = true;
                }
                else
                {
                    logger.LogExit(command);
                    personList[command] = false;

                }
            }
        }
    }
}
