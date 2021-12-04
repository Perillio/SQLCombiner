using System;
using System.IO;

namespace SQLCombiner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int k = 0;
            Console.WriteLine($"Working in directory: {Environment.CurrentDirectory}");
            string[] files = args;
            if (files.Length == 0) 
            {
                Console.WriteLine($"No SQL files found.");
            }
            else
            {
                Console.WriteLine($"Found {files.Length} files.");
                Console.Write($"Checking for SQL files ... ");
                string[] sqls = new string[99999999];
                foreach (string file in files)
                {
                    string x = file.ToLower();
                    if (x.Contains(".sql"))
                    {
                        sqls[k] = x;
                        k++;
                    }
                }
                Console.WriteLine($"{sqls.Length} SQL files found.");
                string filename = $"combinedSQL-{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.sql";
                foreach (string file in sqls)
                {
                    Console.WriteLine($"Reading '{file}' ...");
                    if (file.Contains("sql"))
                    {
                        if (File.Exists(file) && file != "" && file != null)
                        {
                            string[] lines = File.ReadAllLines(file);
                            try
                            {
                                if (File.Exists(filename))
                                {
                                    File.AppendAllLines(filename, lines);
                                }
                                else
                                {
                                    File.WriteAllLines(filename, lines);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR: {ex}");
                            }
                        }
                    }
                }
                Console.WriteLine($"Combined SQL files to '{filename}'");
            }
            Console.WriteLine($"Press ENTER to end.");
            string y = Console.ReadLine();
            if(y != "help")
            {
                Environment.Exit(0);
            }
        }
    }
}
