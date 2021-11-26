using Microsoft.Data.Sqlite;
using PhoneBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model
{
    public class ContactModel
    {
        public ContactModel()
        {
            DatabaseMigration.UpdateDatabase();
        }
        public bool Save(Contact contact)
        {
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand command = new SqliteCommand("INSERT INTO notes(ID, Title, Detail, CreatedAt)" +
                " values (@id, @title, @detail, @created_at)", cnn);
                    command.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@name", contact.Name);                    
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {              
                return false;
            }
        }
    }
}
