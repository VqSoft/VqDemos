using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ConstructorPatterns
{
    /// <summary>
    /// http://www.cnblogs.com/chenssy/archive/2013/05/23/3094138.html
    /// 装饰者模式，动态地将责任附加到对象上。若要扩展功能，装饰者提供了比继承更加有弹性的替代方案。
    /// </summary>
    public sealed class DecoratorPattern
    {
        public static void Test()
        {
            FileInputStream fi = new FileInputStream();

            MemoryInputStream mi = new MemoryInputStream(fi);
            BufferedInputStream bi = new BufferedInputStream(mi);

            bi.Read();
            bi.Write("Hello,inputstream");
        }
    }

    public abstract class InputStream
    {
        public abstract string Read();

        public abstract void Write(string content);
    }

    public class FileInputStream : InputStream
    {
        public override string Read()
        {
            string content = "FileInputStream Read";
            Console.WriteLine(content);

            return content;
        }

        public override void Write(string content)
        {
            Console.WriteLine("FileInputStream Write");
        }
    }

    public class MemoryInputStream : InputStream
    {
        private InputStream stream;
        public MemoryInputStream(InputStream s)
        {
            stream = s;
        }

        public override string Read()
        {
            stream.Read();

            string content = "MemoryInputStream Read";
            Console.WriteLine(content);
            return content;
        }

        public override void Write(string content)
        {
            stream.Write(content);

            Console.WriteLine("MemoryInputStream Write");
        }
    }

    public class BufferedInputStream : InputStream
    {
        private InputStream stream;
        public BufferedInputStream(InputStream s)
        {
            stream = s;
        }

        public override string Read()
        {
            stream.Read();

            string content = "BufferedInputStream Read";
            Console.WriteLine(content);
            return content;
        }

        public override void Write(string content)
        {
            stream.Write(content);

            Console.WriteLine("BufferedInputStream Write");
        }
    }


}
