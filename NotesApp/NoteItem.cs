using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp
{
    public class NoteItem
    {
        private string text;
        public string Text 
        { 
            get { return text; } 
            set { text = value; } 
        }


        private static int count = 0;
        public static int Count
        {
            get { return count; }
            set { count = value; }
        }


        private int id;
        public int Id { get { return id; } set { id = value; } }    

        public NoteItem(string Text) 
        {
           
            this.Text = Text;
            Count++;
            Id = Count;
            
        }
    }
}
