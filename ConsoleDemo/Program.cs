﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0.1f;
            double y = 0.1;

            int?[] arr = new int?[3];
            arr[0] = 1;
            arr[1] = 1;
            arr[2] = null;

            UnmatchedGivingEqualityComparer<int?> o1 = new UnmatchedGivingEqualityComparer<int?>();
            UnmatchedGivingEqualityComparer<int?> o2 = new UnmatchedGivingEqualityComparer<int?>();
            Console.WriteLine(o1.Equals(arr[1],arr[2]));

            //Console.WriteLine(Math.Abs(x - y));
            Console.ReadKey();
        }

        public class UnmatchedGivingEqualityComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {                
                if (object.Equals(y, default(T)) && object.Equals(x, default(T)) )
                {
                    return true;
                }
                if (!object.Equals(y, default(T)) && !object.Equals(x, default(T)))
                {
                    return x.Equals(y);
                }

                return false;
            }


            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }




        private static void RegexSplitString()
        {
            //string str = @"1111_abc,1,22491533_Jo Jo Circus Boy.,2229409_Tara Coulson..,3333_Brown, III,29846399_Luke DeMoss,16338975_Mark DeMoss,30451379_Suzie Donaldson,21579841_Sid Emory,18089661_Nick Floyd,23802795_Coly,nne Gutekunst";
            //string str = "22491533_Jo Jo Circus Boy.,2229409_Tara Coulson..,29846399_Luke DeMoss,3333_Brown, III,23802795_Coly,nne Gutekunst";
            //string str = "aaabbbccc,111_ffff,222_gggg,sf...fff,ss,9999sdfasdfasd";
            //string str = @"111_Rosanne (#289, 292,293,294),121_Testing 1,2,3 delete please,131_26,2008";
            //string str = @"13122222_Van Der Ploeg, Robert,222_Van Der Ploeg, Patricia,333_Wilson, Julie";
            string str = @"afdaf";


            string pattern = @",(?=\d+_)";
            //string pattern = @",(?=\d)";
            //string pattern = @",";

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