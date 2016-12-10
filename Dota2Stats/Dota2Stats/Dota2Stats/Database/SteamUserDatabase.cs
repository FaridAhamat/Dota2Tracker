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
        private SQLiteConnection sqliteConnection;

        public SteamUserDatabase()
        {
            sqliteConnection = DependencyService.Get<ISqlite>().GetConnection();
            sqliteConnection.CreateTable<SteamUserData>();
        }

        public IEnumerable<SteamUserData> GetAllUserData()
        {
            return (from t in sqliteConnection.Table<SteamUserData>() select t).ToList();
        }

        public SteamUserData GetUserData(string accountId)
        {
            return sqliteConnection.Table<SteamUserData>().FirstOrDefault(t => t.AccountId == accountId);
        }

        public void DeleteUserData(string accountId)
        {
            sqliteConnection.Delete<SteamUserData>(accountId);
        }

        public void AddUserData(string accountId, string personaName)
        {
            var steamUser = new SteamUserData
            {
                AccountId = accountId,
                PersonaName = personaName
            };

            sqliteConnection.Insert(steamUser);
            sqliteConnection.Commit();
        }
    }
}
