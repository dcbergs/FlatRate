using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This class is used to put job data in a form that can be read by tabledataview in add/new job section */

namespace FlatRate
{
    class TaskRow
    {
        private string _partName;
        public string partName { get { return _partName; } set { _partName = value; } }

        private string _partDescription;
        public string partDescription { get { return _partDescription; } set { _partDescription = value; } }

        private float _partUnitCost;
        public float partUnitCost { get { return _partUnitCost; } set { _partUnitCost = value; partSubtotal = value * partQuantity; } }

        private float _partQuantity;
        public float partQuantity { get { return _partQuantity; } set { _partQuantity = value; partSubtotal = value * partUnitCost; } }

        private float _partSubtotal;
        public float partSubtotal { get { return _partSubtotal; } set { _partSubtotal = value; } }

        public TaskRow(string name, string description, float unitCost)
        {
            partName = name;
            partDescription = description;
            partUnitCost = unitCost;
            partQuantity = 1;
            partSubtotal = unitCost;
        }

        //this constructor clones the TaskRow
        public TaskRow(TaskRow row)
        {
            partName = row.partName;
            partDescription = row.partDescription;
            partUnitCost = row.partUnitCost;
            partQuantity = row.partQuantity;
            partSubtotal = row.partSubtotal;
        }

        public TaskRow(string name, string description, float unitCost, float quantity)
        {
            partName = name;
            partDescription = description;
            partUnitCost = unitCost;
            partQuantity = quantity;
            partSubtotal = unitCost * quantity;
        }
    }
}
