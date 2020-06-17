using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface ICRUDDAL<T>
    {
        void Create(T obj);
        T Read(int key);
        void Update(T obj);
        void Delete(T obj);
    }
}
