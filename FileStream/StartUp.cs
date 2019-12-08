namespace FileStream
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\Files_and_Collections\Files_and_Collections\Files\MyFile.txt";

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}

            //FileStream fs = File.Create(path);
            //try
            //{
            //    string input;
            //    while ((input = Console.ReadLine()).ToLower() != "end")
            //    {
            //        if (input == "throw")
            //        {
            //            throw new ArgumentException();
            //        }
            //        AddText(fs, input + Environment.NewLine);
            //    }
            //}
            //catch (ArgumentException)
            //{
            //    throw new ArgumentException();
            //}
            //finally
            //{
            //    fs.Close();
            //}

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                string input;
                while ((input = Console.ReadLine()).ToLower() != "end")
                {
                    if (input == "throw")
                    {
                        throw new ArgumentException();
                    }
                    streamWriter.WriteLine(input);
                }
            }
            
        }

        //private static void AddText(FileStream fs, string value)
        //{
        //    byte[] info = new UTF8Encoding(true).GetBytes(value);
        //    fs.Write(info, 0, info.Length);
        //}
    }
}
