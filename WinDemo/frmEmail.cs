using EASendMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
    public partial class frmEmail : frmBase
    {

        private static string UserEmailAbuse = "info@fellowshiponemail.com";
        private static string SendEmailFrom = "fellowshiponemail@activenetwork.com";

        private static string ProcessingMailer = "Fellowship One";

        public frmEmail()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void SendEmail()
        {
            SmtpClient client = CreateSmtpClient();

            SmtpMail mail = new SmtpMail("ES-AA1141023508-00242-EF6F31AB8AE568496AA3E038D842DB03");
            mail.ReplyTo = new MailAddress(txtReplyTo.Text.Trim());
            mail.To.Add(txtToAddress.Text.Trim());
            mail.From = new MailAddress("\"" + txtFromName.Text.Trim() + "\" <" + SendEmailFrom + ">");
            mail.Subject = txtSubject.Text;
            mail.HtmlBody = string.Format("<b>{0}</b>",txtMailBody.Text);

            mail.Headers.AddRange(BuildHeaders());

            client.SendMail(mail);
        }

        public EASendMail.HeaderCollection BuildHeaders()
        {
            var headers = new EASendMail.HeaderCollection();

            headers.Add(new EASendMail.HeaderItem("X-FTEID", new Guid().ToString()));
            headers.Add(new EASendMail.HeaderItem("Sender", SendEmailFrom));
            headers.Add(new EASendMail.HeaderItem("X-Sender", SendEmailFrom));
            headers.Add(new EASendMail.HeaderItem("X-RCPT-TO", SendEmailFrom));
            headers.Add(new EASendMail.HeaderItem("X-Complaints-To", UserEmailAbuse));
            headers.Add(new EASendMail.HeaderItem("X-Mailer", ProcessingMailer));
            headers.Add(new EASendMail.HeaderItem("X-ChurchID", "15"));

            headers.Add("X-xsMessageId", "1111");
            return headers;
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpServer server = new SmtpServer(txtSmtpServer.Text.Trim());
            server.User = txtSMTPUser.Text.Trim();
            server.Password = txtSMTPPwd.Text.Trim();

            SmtpClient client = new SmtpClient();
            client.Connect(server);

            return client;
        }
    }
}
