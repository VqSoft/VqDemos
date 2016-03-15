using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ConstructorPatterns
{
    /// <summary>
    /// http://www.cnblogs.com/chenssy/p/3304390.html
    /// 代理模式就是给一个对象提供一个代理，并由代理对象控制对原对象的引用。
    /// 
    /// </summary>
    public sealed class ProxyPattern
    {
        public static void Test()
        {
            MathProxy proxy = new MathProxy();
            Console.WriteLine("Add : {0}", proxy.Add(1, 2));
            Console.WriteLine("Sub : {0}", proxy.Sub(10, 2));
            Console.WriteLine("Mul : {0}", proxy.Mul(5, 2));
            Console.WriteLine("Div : {0}", proxy.Div(20, 2));
        }
    }

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    public class Math : MarshalByRefObject, IMath
    {

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }


    public class MathProxy : IMath
    {

        private Math mathObj = null;

        public MathProxy()
        {
            AppDomain domain = AppDomain.CreateDomain("MathDomain",null,null);
            System.Runtime.Remoting.ObjectHandle handle = domain.CreateInstance("ConsoleDemo", "ConsoleDemo.DesginPatterns.ConstructorPatterns.Math");
            mathObj = handle.Unwrap() as Math;
        }

        public double Add(double x, double y)
        {
            return mathObj.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return mathObj.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return mathObj.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return mathObj.Div(x, y);
        }
    }



}
