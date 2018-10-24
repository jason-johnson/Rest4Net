using System;
using System.Collections.Generic;

namespace Rest4Net.Test.Repository
{
    public interface IRepository<T, TId>
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T Get(TId id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
    }

    public interface IRepository<T> : IRepository<T, int> {}
}
