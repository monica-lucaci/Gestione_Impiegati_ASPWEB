﻿namespace Gestione_Impiegati_ASPWEB.Repositories
{
    public interface IRepository<T>
    {
        bool Insert(T t);
        T? GetById(int id);
        List<T> GetAll();
        bool Delete(int id);
        bool Update(T t);
    }
}
