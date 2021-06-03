using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDestopClient
{
    public class StorageResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public StorageResponse(bool status, string msg)
        {
            Success = status;
            Message = msg;
        }
    }
}
