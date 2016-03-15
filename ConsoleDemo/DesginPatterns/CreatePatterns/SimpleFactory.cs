using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.CreatePatterns
{
    /// <summary>
    /// 简单工厂模式定义了一个类，这个类专门用于创建其他类的实例，这些被创建的类都有一个共同的父类。
    /// </summary>
    public sealed class SimpleFactory
    {
        public static void Test()
        {
            Pizza p = null;
            SimplePizzaFactory factory = new SimplePizzaFactory();
            p = factory.CreatePizza("clam");
            p.Make();
        }
    }

    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza p = null;

            if (type == "cheese")
            {
                p = new CheesePizza();
            }
            else if (type == "clam")
            {
                p = new ClamPizza();
            }

            return p;
        }

      
    }

    public abstract class Pizza
    {
        public void Make()
        {
            Prepare();
            Bake();
            Cut();
            Box();
        }

        public abstract void Prepare();

        public abstract void Bake();

        public abstract void Cut();

        public abstract void Box();
    }

    public class CheesePizza : Pizza
    {

        public override void Prepare()
        {
            Console.WriteLine(GetType().Name + " Prepare.");
        }

        public override void Bake()
        {
            Console.WriteLine(GetType().Name + " Bake.");
        }

        public override void Cut()
        {
            Console.WriteLine(GetType().Name + " Cut.");
        }

        public override void Box()
        {
            Console.WriteLine(GetType().Name + " Box.");
        }
    }

    public class ClamPizza : Pizza
    {

        public override void Prepare()
        {
            Console.WriteLine(GetType().Name + " Prepare.");
        }

        public override void Bake()
        {
            Console.WriteLine(GetType().Name + " Bake.");
        }

        public override void Cut()
        {
            Console.WriteLine(GetType().Name + " Cut.");
        }

        public override void Box()
        {
            Console.WriteLine(GetType().Name + " Box.");
        }
    }


}
