using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Repositories
{
   public interface ILoginRepository
    {
        public void SetLoginSession(string username, int id);
        public void RemoveLoginSession();
    }
}
