using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ConstructorPatterns
{
    /// <summary>
    ///  桥接模式中的所谓脱耦，就是指在一个软件系统的抽象化和实现化之间使用关联关系（组合或者聚合关系）而不是继承关系，
    ///  从而使两者可以相对独立地变化，这就是桥接模式的用意。
    /// </summary>
    public sealed class BridgePattern
    {
        public static void Test()
        {
            Shape theShape = new Rectangle();
            Color white = new White();
            Color red = new Red();

            theShape.Color = white;
            theShape.Draw();

            theShape.Color = red;
            theShape.Draw();
        }

    }


    public abstract class Shape
    {

        public Color Color {get;set;}

        public abstract void Draw();
    }

    public abstract class Color
    {
        public abstract void Paint(string shape);
    }

    public class Rectangle : Shape
    {

        public override void Draw()
        {
            Color.Paint("Rectangle");
        }
    }

    public class Circle : Shape
    {

        public override void Draw()
        {
            Color.Paint("Circle");
        }
    }

    public class White : Color
    {

        public override void Paint(string shape)
        {
            Console.WriteLine("White {0}",shape);
        }
    }

    public class Red : Color
    {

        public override void Paint(string shape)
        {
            Console.WriteLine("Red {0}",shape);
        }
    }


}
