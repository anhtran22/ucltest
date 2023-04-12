using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment {
    public class Program {

        static string _inputPath = "salg.txt";
        static string _outputPath = "returvarer.txt";
        static List<double> NegativeNumbers = new List<double>();
        static void Main(string[] args) {

            CultureInfo.CurrentCulture = new CultureInfo("da-dk");

            #region Write To Input File
            if (!System.IO.File.Exists(_inputPath)) {
                string[] text = new string[] { "129,95", "-389,95", "-20", "101,50" };

                System.IO.File.WriteAllLines(_inputPath, text.ToArray());
            }
            #endregion

            var tmp = System.IO.File.AppendText(_outputPath);


            foreach (string s in System.IO.File.ReadAllLines(_inputPath)) {
                if (double.TryParse(s, out double number)) {
                    if (number < 0) {
                        NegativeNumbers.Add(number);
                        tmp.Write(number + Environment.NewLine);
                    }
                }
                else {
                    Console.WriteLine("");
                }
            }

            tmp.Write(Environment.NewLine);
            tmp.WriteLine("Sum: " + NegativeNumbers.Sum(x => x));

            tmp.Write(Environment.NewLine);
            tmp.WriteLine("Count: " + NegativeNumbers.Count());

            tmp.Flush();
        }


    }
}
