using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public sealed class AsyncDemo
    {
        #region Await
        public static async void AwaitDemo()
        {
            var task = GetString();
            Console.WriteLine("After: var task = GetString();");

            string theString = await task;//该任务执行完毕后下面的代码才会执行，但不影响主线程代码的执行。
            Console.WriteLine("After: string theString = await task; And the result is {0}", theString);

        }

        public static void TaskWaitDemo()
        {
            var task = GetString();
            Console.WriteLine("After: var task = GetString();");

            task.Wait();//下面的代码不会执行，直到该任务执行完毕，同时会阻塞主线程

            Console.WriteLine("After: task.Wait(););");
        }

        public static void TaskWaitWithParameterDemo()
        {
            var task = GetString();
            Console.WriteLine("After: var task = GetString();");

            task.Wait(2000);

            Console.WriteLine("After: task.Wait(););");
        }

        public static void TaskGetAwaiterDemo()
        {
            var task = GetString();
            Console.WriteLine("After: var task = GetString();");

            string theString = task.GetAwaiter().GetResult();//该任务执行完毕后下面的代码才会执行，同时会阻塞主线程
            Console.WriteLine("After: task.GetAwaiter().GetResult();; And the result is {0}", theString);
        }


        private static async Task<string> GetString()
        {
            await Task.Delay(5000);

            Console.WriteLine("GetString finished, ready to return.");
            return "Get the string";
        }
        #endregion

        public static async void ExceptionInAwaitTask()
        {
            var task = ExceptionMethod();
            try
            {
                await task;//直接抛出ExceptionMethod里面抛出的异常
            }
            catch (Exception ex)
            {
                Console.WriteLine("Meet exception: {0}, \n {1}",ex.Message, ex.GetType().FullName);
                if (ex.InnerException !=null)
                {
                    Console.WriteLine("Inner exception: {0}, \n {1}", ex.InnerException.Message, ex.InnerException.GetType().FullName);
                }
            }
        }

        public static void ExceptionInWait()
        {
            var task = ExceptionMethod();
            try
            {
                task.Wait();//会抛出AggregateException, 并且InnerException是ExceptionMethod抛出的异常
            }
            catch (Exception ex)
            {

                Console.WriteLine("Meet exception: {0}, \n {1}", ex.Message, ex.GetType().FullName);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}, \n {1}", ex.InnerException.Message, ex.InnerException.GetType().FullName);
                }
            }
        }

        public static void ExceptionInGetAwaiter()
        {
            var task = ExceptionMethod();
            try
            {
                var ret = task.GetAwaiter().GetResult();//获取的是ExceptionMethod抛出的异常，但堆栈信息有变化
            }
            catch (Exception ex)
            {

                Console.WriteLine("Meet exception: {0}, \n {1}", ex.Message, ex.GetType().FullName);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}, \n {1}", ex.InnerException.Message, ex.InnerException.GetType().FullName);
                }
            }
        }


        private static async Task<int> ExceptionMethod()
        {
            
            throw new ArgumentException("Exception in ExceptionMethod");

            await Task.Delay(3000);

            return 1;
        }
    }
}
