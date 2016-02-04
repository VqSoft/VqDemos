using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace WinDemo.Mongodb
{
    public sealed class MongoSessionDocument
    {

        private string InnerID = Guid.NewGuid().ToString();

        public MongoSessionDocument()
        {
            ApplicationName = "WinDemo.Mongodb";
            LockId = 0;
            Locked = false;
            Flags = 0;
            User = "ZYTestUser";
            Timeout = 50;
            Created = DateTime.UtcNow;
            LockDate = DateTime.UtcNow;
            Expires = Created.AddMinutes(Timeout);

            SessionStateItemCollection col = new SessionStateItemCollection();
            col["key1"] = new
            {
                ID = new Random().Next(100, 100000),
                Name = "ZY",
                Age = 11
            };
            col["key2"] = new
            {
                ID = new Random().Next(100, 100000),
                Name = "ZY",
                Age = 11
            };
            SessionItems = col;
        }

        public string ID
        {
            get
            {
                return string.Format("{0}.{1}", "WinDemo.Mongodb.", InnerID);
            }
        }

        public string ApplicationName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

        public DateTime LockDate { get; set; }

        public int LockId { get; set; }

        public int Timeout { get; set; }

        public bool Locked { get; set; }

        public SessionStateItemCollection SessionItems { get; set; }

        public int Flags { get; set; }

        public string User { get; set; }


    }
}
