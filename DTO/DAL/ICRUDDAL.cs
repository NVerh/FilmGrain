using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface ICRUDDAL<T>
    {
        public bool Create(T obj);
        public T Read(int key);
        public bool Update(T obj);
        public bool Delete(T obj);
    }
}
