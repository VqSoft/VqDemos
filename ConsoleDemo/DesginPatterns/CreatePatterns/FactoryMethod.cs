using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.CreatePatterns
{
    /// <summary>
    /// 工厂方法模式定义了一个创建对象的接口，但由子类决定要实例化的类是哪一个。工厂方法模式让实例化推迟到子类。
    /// </summary>
    public sealed class FactoryMethod
    {
        public static void Test()
        {
            NewYorkPizzaStore nyStore = new NewYorkPizzaStore();
            Pizza1 p = nyStore.OrderPizza("cheese");
            Console.WriteLine(p.Name);

            ChicagoPizzaStore chicagoStore = new ChicagoPizzaStore();
            Pizza1 chp = chicagoStore.OrderPizza("clam");
            Console.WriteLine(chp.Name);
        }
    }


    public abstract class Pizza1
    {
        protected string name;

        protected string dough;

        protected string sauce;

        protected List<string> Topping = new List<string>();

        public string Name
        {
            get
            {
                return name;
            }
        }

        public virtual void Prepare()
        {
            Console.WriteLine("Prepare: name = {0}, dough={1}, sauce={2}",name,dough,sauce);
            Console.Write("Adding topping:");
            foreach (var tp in Topping)
            {
                Console.WriteLine(tp);
            }
        }

        public virtual void Bake()
        {
            Console.WriteLine(GetType().Name + "Bake");
        }

        public virtual void Cut()
        {
            Console.WriteLine(GetType().Name + "Cut");
        }

        public virtual void Box()
        {
            Console.WriteLine(GetType().Name + "Box");
        }

    }

    public class NewYorkCheesePizza1 : Pizza1
    {
        public NewYorkCheesePizza1()
        {
            name = "NewYorkCheesePizza1";
            dough = "NewYorkCheese dough";
            sauce = "NewYorkCheese sauce";

            Topping.Add("NewYorkCheese topping");
        }
    }

    public class NewYorkClamPizza1 : Pizza1
    {
        public NewYorkClamPizza1()
        {
            name = "NewYorkClamPizza1";
            dough = "NewYorkClam dough";
            sauce = "NewYorkClam sauce";

            Topping.Add("NewYorkClam topping");
        }
    }

    public class ChicagoCheesePizza1 : Pizza1
    {
        public ChicagoCheesePizza1()
        {
            name = "ChicagoCheesePizza1";
            dough = "ChicagoCheese dough";
            sauce = "ChicagoCheese sauce";

            Topping.Add("ChicagoCheese topping");
        }

        public override void Cut()
        {
            Console.WriteLine("Cut in ChicagoCheese style.");
        }
    }

    public class ChicagoClamPizza1 : Pizza1
    {
        public ChicagoClamPizza1()
        {
            name = "ChicagoClamPizza1";
            dough = "ChicagoClam dough";
            sauce = "ChicagoClam sauce";

            Topping.Add("ChicagoClam topping");
        }

        public override void Cut()
        {
            Console.WriteLine("Cut in ChicagoClam style.");
        }
    }

    public abstract class PizzaStore
    {
        public Pizza1 OrderPizza(string type)
        {
            Pizza1 p;

            p = CreatePizza(type);

            p.Prepare();
            p.Bake();
            p.Cut();
            p.Box();

            return p;
        }

        public abstract Pizza1 CreatePizza(string type);

        
    }

    public class NewYorkPizzaStore : PizzaStore
    {
        public override Pizza1 CreatePizza(string type)
        {
            Pizza1 p = null;
            if (type == "cheese")
            {
                p = new NewYorkCheesePizza1();
            }
            else if (type == "clam")
            {
                p = new NewYorkClamPizza1(); 
            }

            return p;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza1 CreatePizza(string type)
        {
            Pizza1 p = null;
            if (type == "cheese")
            {
                p = new ChicagoCheesePizza1();
            }
            else if (type == "clam")
            {
                p = new ChicagoClamPizza1();
            }

            return p;
        }
    }

}
