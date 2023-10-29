using System;
using System.Collections.Generic;

namespace Orders
{
    class Store
    {
        private List<Requisition> requisitions;
        private List<Client> clients;
        private List<Product> products;

        // Переменные хранят номер страницы с таблицей. 
        public static readonly int RequisitionWorkSheet = 3;
        public static readonly int ClientWorkSheet = 2;
        public static readonly int ProductSheet = 1;


        public Store()
        {
            requisitions = new List<Requisition>();
            clients = new List<Client>();
            products = new List<Product>();
        }
        public void Add(IAddData writer)
        {
            if(writer is Requisition)
            {
                requisitions.Add((Requisition)writer);
            }
            if (writer is Client)
            {
                clients.Add((Client)writer);
            }
            if (writer is Product)
            {
                products.Add((Product)writer);
            }
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public List<Client> GetClients()
        {
            return clients;
        }
        public List<Requisition> GetRequisitions()
        {
            return requisitions;
        }
        public void Clear()
        {
            requisitions = new List<Requisition>();
            clients = new List<Client>();
            products = new List<Product>();
        }
    }
}
