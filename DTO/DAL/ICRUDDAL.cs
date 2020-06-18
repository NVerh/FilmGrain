using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface ICRUDDAL<T>
    {
        bool Create(T obj);
        T Read(int key);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
