using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp;
using System.Collections.ObjectModel;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace NotesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditingPage : ContentPage
    {
     
        public EditingPage()
        {
            InitializeComponent();

            SaveNoteCommand = new AsyncCommand(SaveNote);

            EdtingPageEntryField.BindingContext = this;

        }

        public EditingPage(NoteItem noteItem)
        {
            InitializeComponent();

            SaveNoteCommand = new AsyncCommand(SaveNote);

            NoteItemForEditing = new NoteItem();
            NoteItemForEditing = noteItem;
            Text = NoteItemForEditing.Text;

            EdtingPageEntryField.BindingContext = this;

          

        }


        private NoteItem NoteItemForEditing { get; set;}



        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;

            }
        }


        public AsyncCommand SaveNoteCommand { get; }
        async Task SaveNote()
        {
            if (NoteItemForEditing==null)
                await Service.AddNoteToDB(Text);
            else
            {
                NoteItemForEditing.Text = Text;
                Console.WriteLine(await Service.GetNoteByID(NoteItemForEditing.Id));
                await Service.UpdateNoteInDB(NoteItemForEditing);
            }

        }

    }
}