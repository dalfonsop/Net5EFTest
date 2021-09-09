using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServicios.Negocio
{
    public interface ISheetsReaderBusiness
    {
        public byte[] readSheet();
        public  Task<List<Object>> startExec();
    }
}
