using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    /// <summary>
    /// Interface to get the connection from each platform's database
    /// </summary>
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
