using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    interface IAddData
    {
        // Данный интерфейс применяется для записи данных в хранилище Store 
        // вне зависимости от типа класса. 
        void SetValues(List<string> args); // Необходим для инициализации объекта. 
        IAddData Clone(IAddData writer); // Необходим для создания клона объекта. 
    }
}
