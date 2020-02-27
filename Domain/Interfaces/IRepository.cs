using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces {

    public interface IRepository<T> where T : BaseEntity {

        T Create(T obj);

        IList<T> Get();

        T Get(string id);

        void Update(string id, T obj);

        void Remove(string id);
    }
}