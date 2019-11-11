using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteFamilyITSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap memoryImage;
            memoryImage = new Bitmap(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height));
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            string str = "";
            try
            {
                str = string.Format("Screenshot.png");
            }
            catch (Exception er)
            {
                Console.WriteLine("Error occured: " + er.Message);
                Console.ReadKey();
            }

            memoryImage.Save(str);

            SendMail();
        }

        public static void SendMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");


            StreamReader r = new StreamReader(@"..\..\credentials.json");
            string json = r.ReadToEnd();
            List<Credentials> items = JsonConvert.DeserializeObject<List<Credentials>>(json);
            

            
            MessageBox.Show(items[0].username);
            mail.From = new MailAddress(items[0].username);
            mail.To.Add(items[0].reciever);
            mail.Subject = "Screenshot";

            Attachment attachment;
            attachment = new Attachment("Screenshot.png");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential(items[0].username, items[0].password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            MessageBox.Show("mail Send");
        }

        public class Credentials
        {
            public string reciever { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
    }

}