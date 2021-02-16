using EngieApplication.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;


namespace EngieApplication.Services
{
    class QrCode
    {

        public void GenerateQR(string jobRef)
        {
            // Creator: Finn Rea
            // Links to dependancy service for creation of BarCode passing jobRef

           
            Stream QrCodeAsStream = DependencyService.Get<IQrCodeService>().ConvertImageStream(jobRef);       
         
        }

    }
}
