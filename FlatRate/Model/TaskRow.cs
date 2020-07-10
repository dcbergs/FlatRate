using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This class is used to put job data in a form that can be read by tabledataview in add/new job section 
    So far it is the only entity which needs an object representation, essentially represents Tasks_Parts table
    before the task is actually saved (task may not have an ID yet)
     */

namespace FlatRate
{
    class TaskRow
    {
        private string _id;
        public string id { get { return _id; } set { _id = value; } }

        private string _description;
        public string description { get { return _description; } set { _description = value; } }

        private float _unitPrice;
        public float unitPrice { get { return _unitPrice; } set { _unitPrice = value; partSubtotal = value * quantity; } }

        private float _quantity;
        public float quantity { get { return _quantity; } set { _quantity = value; partSubtotal = value * unitPrice; } }

        private float _partSubtotal;
        public float partSubtotal { get { return _partSubtotal; } set { _partSubtotal = value; } }

        public TaskRow(string name, string description, float unitCost)
        {
            id = name;
            this.description = description;
            unitPrice = unitCost;
            quantity = 1;
            partSubtotal = unitCost;
        }

        public TaskRow(string name, string description, float unitCost, float quantity)
        {
            id = name;
            this.description = description;
            unitPrice = unitCost;
            this.quantity = quantity;
            partSubtotal = unitCost * quantity;
        }
    }
}
