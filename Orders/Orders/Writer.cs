using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Orders
{
    class Writer
    {
        private XLWorkbook workbook;
        public Writer(string path)
        {
            workbook = new XLWorkbook(path);
        }
        public string Write(int line, string contacts)
        {
            string cell_number = "D" + line.ToString(); // Указываем ячейку для записи. 

            var worksheet = workbook.Worksheet(Store.ClientWorkSheet);

            worksheet.Cell(cell_number).SetValue(contacts);

            workbook.Save();

            return worksheet.Cell(cell_number).Value.ToString();
        }
    }
}
