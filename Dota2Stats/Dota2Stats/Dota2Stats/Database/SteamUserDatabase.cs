using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public class SteamUserDatabase
    {
        static object locker = new object();

        private SQLiteConnection sqliteConnection;

        public SteamUserDatabase()
        {
            sqliteConnection = DependencyService.Get<ISqlite>().GetConnection();
            sqliteConnection.CreateTable<SteamUserData>();
        }

        public IEnumerable<SteamUserData> GetAllUserData()
        {
            lock (locker)
            {
                return (from t in sqliteConnection.Table<SteamUserData>() select t).ToList();
            }
        }

        public SteamUserData GetUserData(string accountId)
        {
            lock (locker)
            {
                return sqliteConnection.Table<SteamUserData>().FirstOrDefault(t => t.AccountId == accountId);
            }
        }

        public void DeleteUserData(string accountId)
        {
            lock (locker)
            {
                sqliteConnection.Delete<SteamUserData>(accountId);
            }
        }

        public void AddUserData(string accountId, string personaName)
        {
            lock (locker)
            {
                var steamUser = new SteamUserData
                {
                    AccountId = accountId,
                    PersonaName = personaName
                };

                sqliteConnection.Insert(steamUser);
            }
        }
    }
}
