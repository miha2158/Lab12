using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Countries_Lab11;

using static System.Console;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList

            WriteLine("ArrayList");
            var Al = new ArrayList(5);
            Al.Add("123");
            Al.Add(122);
            Al.Add('c');
            Al.Add(new List<int>(0));
            
            foreach (var v in Al)
                WriteLine("{0}",v);
            WriteLine();

            Al[2] = 1;
            Al[1] = new DateTime(2017,5,25,13,49,54);
            Al[3] = new int[0];

            foreach (var v in Al)
                WriteLine("{0}", v);
            WriteLine();

            try
            {
                WriteLine("индекс \'new int[0]\' - {0}, Обычный поиск\n", Al.IndexOf(new int[0]));
            }
            catch (Exception)
            {
                WriteLine("No");
            }
            WriteLine();

            try
            {
                Al.Sort();
            }
            catch (Exception)
            {
                WriteLine("Not sorted");
            }
            WriteLine();

            foreach (var v in Al)
                WriteLine("{0}", v);
            WriteLine();

            try
            {
                WriteLine("индекс \'new int[0]\' - {0}, Бинарный поиск\n", Al.BinarySearch(new int[0]));
            }
            catch (Exception)
            {
                WriteLine("Unable to find");
            }
            WriteLine();

            Al.Clear();
            foreach (var v in Al)
                WriteLine("{0}", v);
            WriteLine();

            #endregion


            #region Stack

            WriteLine();
            WriteLine("Stack");
            WriteLine();

            var st = new Stack<string>();
            
            st.Push("-0");
            foreach (string s in st)
                WriteLine(s);
            WriteLine();

            st.Push(st.Peek());
            st.Push("12345");
            st.Push(st.Count.ToString());
            foreach (string s in st)
                WriteLine(s);
            WriteLine();

            st.Push(st.Pop());
            foreach (string s in st)
                WriteLine(s);
            WriteLine();

            st.Clear();
            foreach (string s in st)
                WriteLine(s);
            WriteLine();

            #endregion Stack


            #region MyDictionary

            WriteLine();
            WriteLine("MyDictionary");
            WriteLine();

            var md = new MyDictionary<Country>(3);
            
            md.Add(new Republic("1",900,"C1","R1",new []{"P1"}));

            var mdCopy = (MyDictionary<Country>)(md.Clone());

            foreach (Country c in mdCopy.Values)
                WriteLine(c);
            WriteLine();

            var mon = new Monarchy("2", 5, "55", "R1");
            md.Add(mon);
            mdCopy.Add(new Kingdom("2",100,"C2","K1"));

            foreach (Country c in mdCopy.Values)
                WriteLine(c);
            WriteLine();

            foreach (Country c in md.Values)
                WriteLine(c);
            WriteLine();

            md.AddRange(mdCopy);

            foreach (Country c in mdCopy.Values)
                WriteLine(c);
            WriteLine();

            mdCopy.Clear();

            WriteLine("md.comtains('{0}') == '{1}'",mon,md.ContainsValue(mon));
            md.Remove(mon);
            
            #endregion

            ReadKey(true);
        }
    }
}
