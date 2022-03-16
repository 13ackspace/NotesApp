using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesApp
{
    public class NoteItemViewModel
    {
        private ObservableCollection<NoteItem> noteItems = new ObservableCollection<NoteItem>
                {
                    new NoteItem("Make homework")
                };
        public ObservableCollection<NoteItem> NoteItems
        {
            get { return noteItems; }
            set { noteItems = value; }
        }



        public NoteItemViewModel() 
        {
        }

        //Navigation to a editing page
        public ICommand CreateNewNoteCommand => new Command(CreateNewNote);
        void CreateNewNote()
        {
            NoteItems.Add(new NoteItem("default"));
            foreach (NoteItem item in NoteItems)
            {
                Console.WriteLine(item.Text);
            }
            Console.WriteLine(NoteItems.Count);
            var editingPage = new EditingPage();
            var noteItem = new NoteItem(NoteItems[NoteItems.Count - 1].Text);
            editingPage.BindingContext = noteItem; 
            Application.Current.MainPage.Navigation.PushAsync(editingPage);
        }

        //Creation of a new note inside the editing page

        private string newNoteInputValue;
        public string NewNoteInputValue
        {
            get { return newNoteInputValue; }
            set { newNoteInputValue = value; }
        }

        public ICommand SaveNewNoteCommand => new Command(SaveNewNote);
        void SaveNewNote()
        {
            foreach (NoteItem item in NoteItems)
            {
                Console.WriteLine(item.Text);
            }
            NoteItems[NoteItems.Count].Text = NewNoteInputValue;
        }

        
        
    }
}
