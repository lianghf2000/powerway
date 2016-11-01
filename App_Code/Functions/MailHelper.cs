using System.Net.Mail;


    public class MailHelper
    {
        public static void Send(string title, string content, string mailto)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(mailto);
            msg.From = new MailAddress("czcz1024@126.com", "czcz", System.Text.Encoding.UTF8);
            //msg.From = new MailAddress("czcz1024@gmail.com", "czcz", System.Text.Encoding.UTF8);
            msg.Subject = title;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            
            SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("czcz1024@gmail.com", "801024");
            client.Credentials = new System.Net.NetworkCredential("czcz1024@126.com", "801024");
            //使用gmail
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            
            client.Host = "smtp.126.com";
            object userState = msg;
            //try
            {
                //client.SendAsync(msg, userState);
                client.Send(msg);
            }
            //catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }
    }

