using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using _1exception;

namespace _1exception
{
    class DoFiles
    {
        private static int sum = 0;
        private static int count = 0;
        public static void ReadFiles(List<string> files, List<string> nofiles, List<string> badData, List<string> overflowData)
        {
            foreach (string file in files)
            {
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    Operations(lines, file, overflowData);
                }
                catch (IndexOutOfRangeException)
                {
                    badData.Add(file);
                }
                catch (FileNotFoundException)
                {
                    nofiles.Add(file);
                }
                catch (FormatException)
                {
                    badData.Add(file);
                }
            }
        }
        public static void Operations(string[] lines, string file, List<string> overflowData)
        {
            try
            {
                int num1 = Convert.ToInt32(lines[0]);
                int num2 = Convert.ToInt32(lines[1]);
                int mult = checked(num1 * num2);
                sum += mult;
                count++;
            }
            catch (OverflowException)
            {
                overflowData.Add(file);
            }
        }
        public static double Average()
        {
            return (double)sum / count;
        }
        public static void CreateFiles(List<string> nofiles, List<string> badData, List<string> overflowData)
        {
            File.WriteAllLines(@"C:\c#labs\1exception\1exception\TXT\no_file.txt", nofiles);
            File.WriteAllLines(@"C:\c#labs\1exception\1exception\TXT\bad_data.txt", badData);
            File.WriteAllLines(@"C:\c#labs\1exception\1exception\TXT\overflow.txt", overflowData);
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<string> files = new List<string>
            {
                @"C:\c#labs\1exception\1exception\TXT\10.txt",
                @"C:\c#labs\1exception\1exception\TXT\11.txt",
                @"C:\c#labs\1exception\1exception\TXT\12.txt",
               @"C:\c#labs\1exception\1exception\TXT\13.txt",
                @"C:\c#labs\1exception\1exception\TXT\14.txt",
                @"C:\c#labs\1exception\1exception\TXT\15.txt",
                @"C:\c#labs\1exception\1exception\TXT\16.txt",
                @"C:\c#labs\1exception\1exception\TXT\17.txt",
                @"C:\c#labs\1exception\1exception\TXT\18.txt",
                @"C:\c#labs\1exception\1exception\TXT\19.txt",
                @"C:\c#labs\1exception\1exception\TXT\20.txt",
                @"C:\c#labs\1exception\1exception\TXT\21.txt",
                @"C:\c#labs\1exception\1exception\TXT\22.txt",
                @"C:\c#labs\1exception\1exception\TXT\23.txt",
                @"C:\c#labs\1exception\1exception\TXT\24.txt",
                @"C:\c#labs\1exception\1exception\TXT\25.txt",
                @"C:\c#labs\1exception\1exception\TXT\26.txt",
                @"C:\c#labs\1exception\1exception\TXT\27.txt",
                @"C:\c#labs\1exception\1exception\TXT\28.txt",
                @"C:\c#labs\1exception\1exception\TXT\29.txt",
            };
        List<string> nofiles = new List<string>();
        List<string> badData = new List<string>();
        List<string> overflowData = new List<string>();
        DoFiles.ReadFiles(files, nofiles, badData, overflowData);
        DoFiles.CreateFiles(nofiles, badData, overflowData);
        double average = DoFiles.Average();
        Console.WriteLine($"Average of products: {average}");
    }
}

