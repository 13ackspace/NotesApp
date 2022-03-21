using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal static class Service
    {
        static SQLiteAsyncConnection db;
        async static Task Init()
        {
            if (db == null)
            {
                var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "NotesData.db");


                db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<NoteItem>();
            }
        }

        public static async Task AddNoteToDB(string text)
        {
            await Init();
            var noteItem = new NoteItem
            {
                Text = text
            };
            await db.InsertAsync(noteItem);
        }

        public static async Task RemoveNoteFromDB(int id)
        {
            await Init();

            await db.DeleteAsync<NoteItem>(id);

            
        }

        public static async Task <IEnumerable<NoteItem>> GetNotesFromDB()
        {
            await Init();

            var noteItem = await db.Table<NoteItem>().ToListAsync();
            return noteItem;
        }

        public async static Task<NoteItem> GetNoteByID(int id)
        {
            await Init();

            return await db.Table<NoteItem>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
        public async static Task<int> UpdateNoteInDB(NoteItem noteItem)
        {
            await Init();
            return await db.UpdateAsync(noteItem);
        }
    }
}
