using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Requisition : IAddData
    {
        public string Requisition_id { get; private set; }
        public string Product_id { get; private set; }
        public string Client_id { get; private set; }
        public string Number { get; private set; }
        public string Count { get; private set; }
        public string Date { get; private set; }
        public void SetValues(List<string> args)
        {
            // Реализация интерфейса для заполнения объекта значениями. 
            Requisition_id = args[0];
            Product_id = args[1];
            Client_id = args[2];
            Number = args[3];
            Count = args[4];
            Date = args[5];
        }
        public IAddData Clone(IAddData obj)
        {
            // Реализация интерфейса для создания клона. 
            IAddData new_obj = new Requisition();
            obj = (Requisition)obj;

            new_obj.SetValues(new List<string>() { ((Requisition)obj).Requisition_id, 
                                                    ((Requisition)obj).Product_id, 
                                                    ((Requisition)obj).Client_id, 
                                                    ((Requisition)obj).Number,
                                                    ((Requisition)obj).Count,
                                                    ((Requisition)obj).Date,
                                                  });
            return new_obj;
        }
    }
}
