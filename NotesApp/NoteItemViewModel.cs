using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System.Linq;

namespace NotesApp
{

    

    public class NoteItemViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set 
            { 
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ObservableRangeCollection<NoteItem> NoteItems { get; set; }


        public NoteItemViewModel() 
        {
            NoteItems = new ObservableRangeCollection<NoteItem>();

            OpenNoteForEditingCommand = new AsyncCommand<NoteItem>(OpenNoteForEditing);
            CreateNewNoteCommand = new AsyncCommand(CreateNewNote);
            RemoveNoteCommand = new AsyncCommand<NoteItem>(RemoveNote);
            RefreshCommand = new AsyncCommand(Refresh);

            IsRefreshing = false;

            Refresh();
        }

       


        public AsyncCommand<NoteItem> OpenNoteForEditingCommand { get; }
        async Task OpenNoteForEditing(NoteItem noteItem)
        {
            
            var editingPage = new EditingPage(noteItem);
            await Application.Current.MainPage.Navigation.PushAsync(editingPage);
        }



        public AsyncCommand CreateNewNoteCommand { get; }
        async Task CreateNewNote()
        {


            var editingPage = new EditingPage();
            await Application.Current.MainPage.Navigation.PushAsync(editingPage);
        }

        public AsyncCommand<NoteItem> RemoveNoteCommand { get; }
        async Task RemoveNote(NoteItem NoteItemBeingRemoved)
        {
            await Service.RemoveNoteFromDB(NoteItemBeingRemoved.Id);
            await Refresh();

        }
       
        public AsyncCommand RefreshCommand { get; }
        public async Task Refresh()
        {

            NoteItems.Clear();
            var NoteItemsBeingRefreshed = await Service.GetNotesFromDB();
            NoteItems.AddRange(NoteItemsBeingRefreshed);

            IsRefreshing = false;

        }
        
    }
}
