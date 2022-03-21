using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
        }

        
        async void OpenEditingPage(object sender, EventArgs e)
        {
            var editingPage = new EditingPage();
            await Application.Current.MainPage.Navigation.PushAsync(editingPage);
        }
    }
}
