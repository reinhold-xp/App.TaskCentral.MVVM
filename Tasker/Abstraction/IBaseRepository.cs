using System;
using System.Linq.Expressions;

namespace Tasker.Abstraction
{
    // Interface IDisposable (méthode close),
    // implémentable uniquement par les classes du type TableData
    public interface IBaseRepository<T> : IDisposable
        where T : TableData, new()

    {
        void CreateItem(T item);

        void UpdateItem(T item);

        T GetItem(int id);

        List<T> GetItems();

        void DeletItem(T item);

    }
}

