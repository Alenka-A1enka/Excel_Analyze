using System;
using System.Collections.Generic;

namespace Orders
{
    class Product : IAddData
    {
        public string Product_id { get; private set; }
        public string Name { get; private set; }
        public string Unit { get; private set; }
        public string Price { get; private set; }
        public void SetValues(List<string> args)
        {
            // Реализация интерфейса для заполнения объекта значениями. 
            Product_id = args[0];
            Name = args[1];
            Unit = args[2];
            Price = args[3];
        }
        public IAddData Clone(IAddData obj)
        {
            // Реализация интерфейса для создания клона. 
            IAddData new_obj = new Product();
            obj = (Product)obj;

            new_obj.SetValues(new List<string>() { ((Product)obj).Product_id, 
                                                   ((Product)obj).Name, 
                                                   ((Product)obj).Unit, 
                                                   ((Product)obj).Price 
                                                });
            return new_obj;
        }
    }
}
