using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EngieApplication.Interface;
using System;
using Android.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using EngieApplication.Droid;
using System.Net.Mail;
using System.Net;

[assembly: Dependency(typeof(QrCodeService))]
namespace EngieApplication.Droid
{
    public class QrCodeService : IQrCodeService
    {

        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// 
        /// Dependancy service for creation barcodes from a job referance.
        /// It had to be done in a dependancy service to allow for android create a bitmap 
        /// Barcode is stored in internal memory 
        /// This barcode is read from engie27345@gmail.com email
        /// 
        /// 
        /// 
        /// 
        /// </summary>



        public Stream ConvertImageStream(string jobref, int width = 300, int height = 130)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_39,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 10
                }
            };

            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            Bitmap bitmap = barcodeWriter.Write(jobref);
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);  
            // this is the diff between iOS and Android
            
            stream.Position = 0;






            WriteToEmail(stream, jobref);



            return stream;
        }




        private void WriteToEmail(Stream stream, string jobref)
        {
           
            string fileName = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), jobref+ ".png");

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }





            string subject = jobref;
            string body = "JobRef: " + jobref;
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("engie27345@gmail.com");
            mail.To.Add("engie27345@gmail.com");
            mail.Subject = subject;
            mail.Body = body;
            System.Net.Mail.Attachment attachment;
            attachment = new Attachment(fileName);
            mail.Attachments.Add(attachment);
            smtpServer.Credentials = new NetworkCredential("engie27345", "Pa$$w0rd1!");

            smtpServer.UseDefaultCredentials = false;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);

        }



    }
}