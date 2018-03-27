using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransDevCS
{
    public class ClassService
    {
        public int IDService;
        public string LibelleService;

        public ClassService(int idService, string libelleService)
        {
            this.IDService = idService;
            this.LibelleService = libelleService;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.LibelleService);
        }
    }
}
