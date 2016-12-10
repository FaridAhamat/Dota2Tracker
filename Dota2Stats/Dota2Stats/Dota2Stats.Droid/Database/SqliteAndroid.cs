using System;
using System.IO;
using SQLite.Net;
using Dota2Stats.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace Dota2Stats.Droid
{
    public class SqliteAndroid : ISqlite
    {
        public SqliteAndroid()
        {
        }

        public SQLiteConnection GetConnection()
        {
            string fileName = "SteamUserData.db3";
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var fullPath = Path.Combine(docsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            return new SQLiteConnection(platform, fullPath);
        }
    }
}