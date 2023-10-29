using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Client : IAddData
    {
        public string Client_id { get; private set; }
        public string Company { get; private set; }
        public string Address { get; private set; }
        public string Person { get; private set; }
        public void SetValues(List<string> args)
        {
            // Реализация интерфейса для заполнения объекта значениями. 
            Client_id = args[0];
            Company = args[1];
            Address = args[2];
            Person = args[3];
        }
        public IAddData Clone(IAddData obj)
        {
            // Реализация интерфейса для создания клона. 
            IAddData new_obj = new Client();
            obj = (Client)obj;

            new_obj.SetValues(new List<string>() { ((Client)obj).Client_id, 
                                                   ((Client)obj).Company, 
                                                   ((Client)obj).Address, 
                                                   ((Client)obj).Person });
            return new_obj;
        }
    }
}
