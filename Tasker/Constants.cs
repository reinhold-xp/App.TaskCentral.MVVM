using System;
using SQLite;

namespace Tasker
{
	public static class Constants
	{
        private const string _DB_FILENAME = "database.db3";

        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;

        public static string DB_PATH
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, _DB_FILENAME);
            }
        }
    }
}

