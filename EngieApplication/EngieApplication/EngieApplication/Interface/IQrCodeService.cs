using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EngieApplication.Interface
{
    public interface IQrCodeService
    {

        /// <summary>
        /// Creator: Finn Rea
        /// This is a interface for converting text into a Barcode stream 
        /// This is for dependancy injection to initlze onject before deciding device being used.
        /// Then the dependancy can be "injected"
        /// </summary>


        Stream ConvertImageStream(string text, int width = 300, int height = 130);

    }
}
