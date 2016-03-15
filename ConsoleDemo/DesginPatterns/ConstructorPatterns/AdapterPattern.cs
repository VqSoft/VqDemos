using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ConstructorPatterns
{
    /// <summary>
    ///  在适配器模式中，我们可以定义一个包装类，包装不兼容接口的对象，这个包装类就是适配器，它所包装的对象就是适配者。
    /// </summary>
    public sealed class AdapterPattern
    {
        public static void Test()
        {
            PlainTextAccess txtAccess = new PlainTextAccess();
            DBAccess dbaccess = new PlainTextAdapter(txtAccess);
            dbaccess.ReadDB();
            dbaccess.WriteDB("My content");
        }
    }

    public abstract class DBAccess
    {
        public abstract string ReadDB();

        public abstract void WriteDB(string content);
    }

    public class MSSqlDBAccess : DBAccess
    {
        public override string ReadDB()
        {
            string content = "Read from MSSQL DB.";
            Console.WriteLine(content);

            return content;
        }

        public override void WriteDB(string content)
        {
            Console.WriteLine("{0} has been write to MSSQL DB.",content);
        }
    }

    public class PlainTextAccess
    {
        public string ReadFile()
        {
            string content = "Read from Plain Text";
            Console.WriteLine(content);

            return content;
        }

        public void WriteFile(string content)
        {
            Console.WriteLine("{0} has been write to Plain Text.", content);
        }
    }

    public class PlainTextAdapter : DBAccess
    {
        private PlainTextAccess plainTxtAccess;

        public PlainTextAdapter(PlainTextAccess txtAccess)
        {
            plainTxtAccess = txtAccess;
        }

        public override string ReadDB()
        {
            Console.WriteLine("Read via PlainTextAdapter");
            return plainTxtAccess.ReadFile();
        }

        public override void WriteDB(string content)
        {
            Console.WriteLine("Write via PlainTextAdapter");
            plainTxtAccess.WriteFile(content);
        }
    }



}
