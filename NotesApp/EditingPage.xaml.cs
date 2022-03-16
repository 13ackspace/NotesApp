using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp;
using System.Collections.ObjectModel;

namespace NotesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditingPage : ContentPage
    {
        public EditingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PopAsync();
        }
    }
}