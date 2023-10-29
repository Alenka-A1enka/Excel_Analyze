using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    static class StoreAnalyze
    {
        public static string BestClient(Store store, int year, int month = -1)
        {
            // Получение всех заявок. 
            List<Requisition> all_requisition = store.GetRequisitions();

            // Выбор нужной фильтрации. 
            var requistion = all_requisition.Where(r => ListFilterByYearAndMonth(r, year, month));
            if (month == -1)
            {
                requistion = all_requisition.Where(r => ListFilterByYear(r, year));
            }


            Dictionary<string, int> dict = new Dictionary<string, int>();
            // Создание словаря, где ключи - код клиента, значение - кол-во заявок клиента. 
            foreach (var r in requistion)
            {
                int count;
                if (!dict.TryGetValue(r.Client_id, out count))
                {
                    dict.Add(r.Client_id, 0);
                }
                dict[r.Client_id] = ++count;
            }

            if (dict.Count == 0) return ": нет (за данный период заявок не было)";

            // Выбор одного клиента, у которого больше всех заявок. 
            var client_id = dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return GetClientNameById(store, client_id);
        }
        private static bool ListFilterByYear(Requisition r, int year)
        {
            // Функция фильтрации только по году. 
            return DateTime.Parse(r.Date).Year == year;
        }
        private static bool ListFilterByYearAndMonth(Requisition r, int year, int month)
        {
            // Функция фильтрации по году и месяцу. 
            return DateTime.Parse(r.Date).Year == year && DateTime.Parse(r.Date).Month == month;
        }
        public static List<string> ProductInfoAnalyze(Store store, Product product)
        {
            List<string> list = new List<string>();

            // Получение списка всех заявок. 
            List<Requisition> all_requisitions = store.GetRequisitions();

            // Фильтрация заявок: отбираются только для данного продукта. 
            var requisitions = all_requisitions.Where(r => r.Product_id == product.Product_id);
            foreach(var r in requisitions)
            {
                list.Add("Клиент " + StoreAnalyze.GetClientNameById(store, r.Client_id));
                list.Add("Количество " + r.Count);
                list.Add("Цена товара "+ product.Price);
                list.Add("Сумма "+ (Convert.ToInt32(r.Count) * Convert.ToInt32(product.Price)).ToString());
                list.Add("Дата заказа "+ r.Date);
                list.Add("");
            }

            return list;
        }
        public static string GetClientNameById(Store store, string client_id)
        {
            // Получение ФИО клиента по его коду. 

            List<Client> all_clients = store.GetClients();
            var client = all_clients.Where(c => c.Client_id == client_id);
            return client.First().Person;
        }
    }
}
