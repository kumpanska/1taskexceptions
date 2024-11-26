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

            }
            catch (OverflowException)
            {
                overflowData.Add(file);
            }
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
    }
}

