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
    public partial class CreateAsset : ContentPage
    {
        public CreateAsset()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new ChooseAsset(page);
        }
       
    }
}