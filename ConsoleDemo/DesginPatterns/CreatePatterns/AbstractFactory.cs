using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.CreatePatterns
{
    /// <summary>
    ///  抽象工厂模式提供一个接口，用于创建相关或者依赖对象的家族，而不需要明确指定具体类。
    /// </summary>
    public sealed class AbstractFactory
    {
        public static void Test()
        {
            ChinaFactory factory = new HaierFactory();
            AirConditioner ac1 = factory.CreateAircondition();
            Fridge f1 = factory.CreateFridge();
            Console.WriteLine(ac1.Name);
            Console.WriteLine(f1.Name);

            ChinaFactory greeFactory = new GreeFactory();
            AirConditioner ac2 = greeFactory.CreateAircondition();
            Fridge f2 = greeFactory.CreateFridge();
            Console.WriteLine(ac2.Name);
            Console.WriteLine(f2.Name);
        }
    }//class


    public abstract class ChinaFactory
    {
        public abstract AirConditioner CreateAircondition();

        public abstract Fridge CreateFridge();
    }

    public class HaierFactory : ChinaFactory
    {

        public override AirConditioner CreateAircondition()
        {
            AirConditioner p = new HaierAirconditioner();
            p.Name = "HaierAirconditioner"; ;

            return p;
        }

        public override Fridge CreateFridge()
        {
            Fridge p = new HaierFridge();
            p.Name = "HaierFridge";

            return p;
        }
    }

    public class GreeFactory : ChinaFactory
    {

        public override AirConditioner CreateAircondition()
        {
            AirConditioner p = new GreeAirconditioner();
            p.Name = "GreeAirconditioner";

            return p;
        }

        public override Fridge CreateFridge()
        {
            Fridge p = new GreeFridge();
            p.Name = "GreeFridge";

            return p;
        }
    }


    public abstract class ChinaProduct
    {
        public string Name { get; set; }
    }

    public abstract class AirConditioner : ChinaProduct
    {

    }

    public abstract class Fridge : ChinaProduct
    {

    }

    public class HaierAirconditioner : AirConditioner
    {

    }

    public class HaierFridge : Fridge
    {

    }


    public class GreeAirconditioner : AirConditioner
    {

    }

    public class GreeFridge : Fridge
    {

    }



}
