using EngieApplication.Services;
using EngieApplication.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace EngieApplication.ViewModels
{
    class SendEmailViewModel
    {
        /// <summary>
        /// Creator: Kacper Stawski
        /// 
        /// This is the view model for sending an email from Contact.xaml.
        /// Subject and body are passed here and inserted into an email message 
        /// which is sent to Engie's email account.
        /// 
        /// 
        /// </summary>


        PageService pageService = new PageService();

        string subject;
        string body;

        public SendEmailViewModel()
        {
            SendEmailCommand = new Command(async () => await WriteToEmail());
        }

        public Command SendEmailCommand { get; }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        public async Task WriteToEmail()
        {
            Person worker = (Person)Application.Current.Properties["LoggedIn"];

            string subject = Subject;
            string body = Body + "\n \n" + "User's details:" + "\n" + worker.Name + "\n" + worker.PersonId
                          + "\n" + worker.Company + "\n" + worker.Email + "\n" + worker.PhoneNumber;

            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("engie27345@gmail.com");
            mail.To.Add("engie27345@gmail.com");
            mail.Subject = subject;
            mail.Body = body;

            // We've run of time and did not manage to implement any security measures here
            smtpServer.Credentials = new NetworkCredential("engie27345", "Pa$$w0rd1!");

            smtpServer.UseDefaultCredentials = false;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);

            await pageService.DisplayAlert("Success", "Message sent successfully", "Ok");
            await pageService.PushAsync(new WorkerPages.WorkerMainPage());

        }
    }
}
