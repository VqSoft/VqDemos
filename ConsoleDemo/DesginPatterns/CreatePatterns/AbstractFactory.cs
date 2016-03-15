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

    }//class


    public abstract class ChinaFactory
    {
        
    }

    public class HaierFactory : ChinaFactory
    {

    }

    public class GreeFactory : ChinaFactory
    {

    }


    public abstract class ChinaProduct
    {
        public string Name { get; set; }
    }

    public  class HaierAirconditioner : ChinaProduct
    {

    }

    public  class HaierFridge : ChinaProduct
    {

    }


    public  class GreeAirconditioner : ChinaProduct
    {

    }

    public class GreeFridge : ChinaProduct
    {

    }



}
