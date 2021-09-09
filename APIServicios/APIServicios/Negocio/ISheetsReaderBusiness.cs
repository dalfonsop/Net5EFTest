using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServicios.Negocio
{
    public interface ISheetsReader
    {
        public byte[] readSheet();
    }
}
