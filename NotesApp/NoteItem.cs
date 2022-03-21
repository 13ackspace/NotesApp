using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NotesApp
{
    public class NoteItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string text;
        public string Text 
        { 
            get { return text; } 
            set 
            { 
                if(text != value) 
                { 
                    text = value; 
                    NotifyPropertyChanged();
                }
            } 
        }

        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; } }    

        public NoteItem()
        { 
            
        }
    }
}
