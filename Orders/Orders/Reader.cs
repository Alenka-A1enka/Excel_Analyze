using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Orders
{
    class Reader
    {
        private XLWorkbook workbook;
        public Reader(string path)
        {
            workbook = new XLWorkbook(path);
        }
        public void Read(int sheet_number, Store store, IAddData writer)
        {
            string str = "";

            var worksheet = workbook.Worksheet(sheet_number);
            var rows = worksheet.RangeUsed().RowsUsed();

            int count = worksheet.RangeUsed().ColumnCount();
            int i = 0;

            List<string> values; // Массив будет хранить данные для записи в объект. 
            foreach (var row in rows)
            {
                values = new List<string>();
                // Пропуск заголовков. 
                if (i == 0)
                {
                    i++;
                    continue;
                }
                // Сохраняем строку из таблицы в массив. 
                for(int j = 1; j <= count; j++)
                {
                    str = row.Cell(j).Value.ToString();
                    values.Add(str);
                }
                writer.SetValues(values); // Иницилиализируем класс (через общий интерфейс). 

                // Создание клона объекта, чтобы добавить его в массив. 
                IAddData new_writer = writer.Clone(writer); 
                store.Add(new_writer);
            }
            
        }
    }
}
