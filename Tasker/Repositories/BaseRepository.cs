using SQLite;
using Tasker.Abstraction;

namespace Tasker.Repositories
{ 
	public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
		{
            connection = new SQLiteConnection(Constants.DB_PATH, Constants.FLAGS);
            connection.CreateTable<T>();
        }

        public void DeletItem(T item)
        {
            // Supprimer en cascade : param. recursive = true 
            connection.Delete(item);
        }

        public void Dispose()
        {
            connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return connection.Table<T>()
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }

            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }

            return null;
        }

        public void CreateItem(T item)
        {
            try
            {
                var result = connection.Insert(item);
                StatusMessage = $"{result} row(s) added";

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }
        }

        public void UpdateItem(T item)
        {
            try
            {
                var result = connection.Update(item);
                StatusMessage = $"{result} row(s) updated";

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }
        }
    }
}

