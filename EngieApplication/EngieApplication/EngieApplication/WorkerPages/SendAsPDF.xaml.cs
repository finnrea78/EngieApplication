using EngieApplication.Services;
using EngieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.WorkerPages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendAsPDF : ContentPage
    {
        /// <summary>
        /// Creator: Joe Lewis
        /// 
        /// Page for entering the email and job reference you wish to associate with the sending of
        /// a pdf by email.
        /// 
        /// 
        /// 
        /// 
        /// This should have been completed by Aaron shaote who dropped out hench why it is last minuete
        /// 
        ///</summary>

        //SendPDFViewModel model;

        public SendAsPDF()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new SendPDFViewModel(page);

        }
    }
}