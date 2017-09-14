using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraVitaApp
{
    public class SQLHelper
    {
        static object locker = new object();
        SQLiteConnection database;
        public SQLHelper()
        {
            database = GetConnection();
            // create the tables
            database.CreateTable<Student>();
        }
        public SQLite.SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlitConnection;
            var sqliteFilename = "Employee.db3";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            sqlitConnection = new SQLite.SQLiteConnection(path);
            return sqlitConnection;
        }

        public IEnumerable<Student> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Student>() select i).ToList();
            }
        }
        public Student GetItem(Int64 phone)
        {
            lock (locker)
            {
                return database.Table<Student>().FirstOrDefault(x => x.MobileNo == phone);
            }
        }
        public Student GetItem(Int64 phone, string regID)
        {
            lock (locker)
            {
                return database.Table<Student>().FirstOrDefault(x => x.MobileNo == phone && x.regID == regID);
            }
        }
        public Int64 SaveItem(Student item)
        {
            lock (locker)
            {
                if (item.regID != null)
                {
                    //Update Item
                    database.Update(item);
                    return Int64.Parse(item.regID);
                }
                else
                {
                    //Insert item
                    return database.Insert(item);
                }
            }
        }

        internal int SaveItem(object p)
        {
            throw new NotImplementedException();
        }

        public Int64 DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Student>(id);
            }
        }

    }
}
