using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ActionPatterns
{
    /// <summary>
    /// http://www.cnblogs.com/chenssy/p/3332193.html
    /// 职责链将请求的发送者和请求的处理者解耦了，这就是职责链的设计动机。
    /// </summary>
    public sealed class DutyChain
    {
        public static void Test()
        {
            Leader instructor = new Instructor("王辅导员");
            Leader departmentHead = new DepartmentHead("李主任");
            Leader president = new President("张校长");

            instructor.Successor = departmentHead;
            departmentHead.Successor = president;

            LeaveNode day3 = new LeaveNode(3, "赵阳");
            LeaveNode day7 = new LeaveNode(7, "王辉");
            LeaveNode day20 = new LeaveNode(20, "张晓");

            instructor.HandleRequest(day3);
            instructor.HandleRequest(day7);
            instructor.HandleRequest(day20);
        }

    }

    public class LeaveNode
    {
        public int LeaveDays
        {
            get;
            set;
        }

        public string PersonName
        {
            get;
            set;
        }

        public LeaveNode(int days,string name)
        {
            LeaveDays = days;
            PersonName = name;
        }
    }

    public abstract class Leader
    {
        protected Leader successor;

        public Leader Successor
        {
            set
            {
                successor = value;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public Leader(string name)
        {
            Name = name;
        }

        public abstract void HandleRequest(LeaveNode leave);
    }

    public class Instructor : Leader
    {
        public Instructor(string name):base(name)
        {

        }

        public override void HandleRequest(LeaveNode leave)
        {
            if (leave.LeaveDays <=3)
            {
                Console.WriteLine("辅导员 {0} 批准了 {1} 同学的请假，请假天数为 {2} 天。",Name,leave.PersonName,leave.LeaveDays);
            }
            else
            {
                if (successor != null)
                {
                    successor.HandleRequest(leave);
                }
            }
        }
    }


    public class DepartmentHead : Leader
    {
        public DepartmentHead(string name):base(name)
        {

        }

        public override void HandleRequest(LeaveNode leave)
        {
            if (leave.LeaveDays <= 7)
            {
                Console.WriteLine("系主任 {0} 批准了 {1} 同学的请假，请假天数为 {2} 天。",Name,leave.PersonName,leave.LeaveDays);
            }
            else
            {
                if (successor != null)
                {
                    successor.HandleRequest(leave);
                }
            }
        }
    }

    public class President : Leader
    {
        public President(string name)
            : base(name)
        {

        }

        public override void HandleRequest(LeaveNode leave)
        {
            if (leave.LeaveDays <=15)
            {
                Console.WriteLine("校长 {0} 批准了 {1} 同学的请假，请假天数为 {2} 天。", Name, leave.PersonName, leave.LeaveDays);
            }
            else
            {
                Console.WriteLine("你请假的天数过长，不能批准....");
            }
        }
    }

}
