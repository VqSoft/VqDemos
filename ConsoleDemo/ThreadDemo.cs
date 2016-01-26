using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class ThreadDemo
    {

        public static void ThreadExceptionDemo()
        {
            new Thread(FuncException).Start();
        }

        public static void TaskExceptionDemo()
        {
            var t = Task.Run(() => {
                FuncException();
            });
            t.Wait();
        }

        private static void FuncException()
        {
            throw null;
        }

        public static void Interlocked_CompareExchange_Demo()
        {
            int hitCount = 1;
            Console.WriteLine("The value is : {0}",hitCount);
            Interlocked.CompareExchange(ref hitCount, 2, 0);
            Console.WriteLine("Interlocked.CompareExchange(ref hitCount, 2, 0);,The value is : {0}", hitCount);

            int newHitCount = Interlocked.CompareExchange(ref hitCount, 2, 1);
            Console.WriteLine("Interlocked.CompareExchange(ref hitCount, 2, 1);,The value is : {0},newHitCount is : {1}", hitCount,newHitCount);
        }

    }//class
}
