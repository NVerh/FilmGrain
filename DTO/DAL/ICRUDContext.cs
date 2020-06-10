using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface ICRUDContext<T>
    {
        string Create(T obj);
        T Read(string key);
        void Update(T obj);
        void Delete(T obj);
    }
}
