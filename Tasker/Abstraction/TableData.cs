using System;
using SQLite;

namespace Tasker.Abstraction
{
	public abstract class TableData
	{
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

