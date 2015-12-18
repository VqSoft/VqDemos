using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexSplitString();


            Console.ReadKey();
        }


        private static void RegexSplitString()
        {
            string str = @"22491533_Jo Jo Circus Boy.,2229409_Tara Coulson.., 3333_Brown, III,29846399_Luke DeMoss,16338975_Mark DeMoss,30451379_Suzie Donaldson,21579841_Sid Emory,18089661_Nick Floyd,23802795_Coly,nne Gutekunst";
            //string str = "22491533_Jo Jo Circus Boy.,2229409_Tara Coulson..,29846399_Luke DeMoss,3333_Brown, III,23802795_Coly,nne Gutekunst";
            //string str = "aaabbbccc,111_ffff,222_gggg,sf...fff,ss,9999sdfasdfasd";

            string pattern = @",(?= *\d)";

            var arr = Regex.Split(str, pattern);

            



            Console.WriteLine(arr.Length);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] Split(string target, Regex regex, bool isIncludeMatch = true)
        {
            List<string> list = new List<string>();
            MatchCollection mc = regex.Matches(target);
            int curPostion = 0;
            foreach (Match match in mc)
            {
                if (match.Index != curPostion)
                {
                    list.Add(target.Substring(curPostion, match.Index - curPostion));
                }
                curPostion = match.Index + match.Length;
                if (isIncludeMatch)
                {
                    list.Add(match.Value);
                }
            }
            if (target.Length > curPostion)
            {
                list.Add(target.Substring(curPostion));
            }
            return list.ToArray();
        }  

    }//class
}
