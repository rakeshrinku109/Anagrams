using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int testcases = int.Parse(Console.ReadLine());
            List<string> _inputList = new List<string>();

            for (int i = 0; i < testcases; i++)
            {
                string InputString = new string(Console.ReadLine().Trim().OrderBy(m=>m).ToArray());
                _inputList.Add(InputString);
            }

            foreach (var item in _inputList)
            {
                StringBuilder OP = new StringBuilder();
                foreach (var itemEntry in new List<string>(Iterate(item)))
                {
                    OP.Append(itemEntry);
                    OP.Append(" ");
                }
                Console.WriteLine(OP.ToString().TrimEnd());
            }
        }

        private static HashSet<string> Iterate(string inputString)
        {
              HashSet<string> _output = new HashSet<string>();

              for (int i = 0; i < inputString.Length; i++)
              {
                string element = inputString[i].ToString();
                FindAnagramCombinations(inputString, inputString[i].ToString(), inputString.Remove(i, 1), ref _output);
              }
              return _output;
        }
        static void FindAnagramCombinations(string inputString,string element,string NewString,ref HashSet<string> _output)
        {

            if (NewString.Length > 2)
            {
                foreach (var item in Iterate(NewString.ToString()))
                {
                    AddCombinations(element, item, ref _output);
                }
            }
            else if (NewString.Length == 2)
            {
                foreach (var item in SwapAndReturn(NewString.ToString()))
                {
                    AddCombinations(element, item, ref _output);
                }
            }
            else
            {
                foreach (var item in SwapAndReturn(inputString))
                {
                    _output.Add(item);
                }
            }

        }

        static void AddCombinations(string element,string item, ref HashSet<string> OutPut)
        {
            StringBuilder IPString = new StringBuilder();
            IPString.Append(element);
            IPString.Append(item);
            OutPut.Add(IPString.ToString());
        }

        static HashSet<string> SwapAndReturn(string InputToSwap)
        {
            HashSet<string> _ouptSwap = new HashSet<string>();
            _ouptSwap.Add(InputToSwap);
            StringBuilder OuputToSwap = new StringBuilder();
            OuputToSwap.Append(InputToSwap[1]);
            OuputToSwap.Append(InputToSwap[0]); 
            _ouptSwap.Add(OuputToSwap.ToString());
            return _ouptSwap;
        }
    


    }


}
