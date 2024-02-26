using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDb
{
    static class Global
    {
        //creating a db context and use it whenever I need a connection
        public static TodoDbCtx context = new TodoDbCtx();
    }
}
