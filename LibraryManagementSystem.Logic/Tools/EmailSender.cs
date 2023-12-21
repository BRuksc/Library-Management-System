using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.Logic.Tools
{
    public static class EmailSender
    {
        public static bool Send
            (string from, string to, string subject, string name, string body, string fromPass)
        {
            byte[] encodedByteFrom = Encoding.Default.GetBytes(from);
            from = UTF8Encoding.Default.GetString(encodedByteFrom);

            byte[] encoddedByteTo = Encoding.Default.GetBytes(to);
            to = UTF8Encoding.Default.GetString(encoddedByteTo);

            byte[] encodedByteSubject = Encoding.Default.GetBytes(subject);
            subject = UTF8Encoding.Default.GetString(encodedByteSubject);

            byte[] encodedByteName = Encoding.Default.GetBytes(name);
            name = UTF8Encoding.Default.GetString(encodedByteName);

            byte[] encodedByteBody = Encoding.Default.GetBytes(body);
            body = UTF8Encoding.Default.GetString(encodedByteBody);

            byte[] encodedByteFromPass = Encoding.Default.GetBytes(fromPass);
            fromPass = UTF8Encoding.Default.GetString(encodedByteFromPass);

            MailMessage message = new MailMessage();

            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(from, fromPass);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                            (ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}