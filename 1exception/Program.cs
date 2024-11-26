using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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
    }
}

