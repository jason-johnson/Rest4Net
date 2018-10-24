using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest4Net.Test.Repository
{
    public class TestRepository<T> : IRepository<T, int>
    {
        protected List<T> Collection { get; }

        public TestRepository(IEnumerable<T> collection)
        {
            Collection = collection.ToList();
        }

        public void Add(T item)
        {
            Collection.Add(item);
        }

        public T Get(int id)
        {
            return Collection[id];
        }

        public IEnumerable<T> GetAll()
        {
            return Collection;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            var query = from c in Collection
                    where predicate(c)
                    select c;

            return query;
        }

        public void Remove(T item)
        {
            Collection.Remove(item);
        }

        public void Update(T item)
        {
            // Nothing to do here
        }
    }
}
