using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class PartList
    {
        private Dictionary<string, Part> _partList;
        public Dictionary<string, Part> partList { get { return _partList; } }

        //private List<Part> _partList;
        //public List<Part> partList { get { return _partList; } }

        public PartList()
        {
            // _partList = new List<Part>();
            _partList = new Dictionary<string, Part>();
        }

        //adds a part if there isn't one by that ID already, otherwise overwrites it.
        //returns a boolean for whether or not a part was overwritten
        public bool addPart(Part newPart)
        {
            bool overwritten = false;

            if(partList.ContainsKey(newPart.partID))
            {
                partList[newPart.partID] = newPart;
                overwritten = true;
            }
            else
            {
                partList.Add(newPart.partID, newPart);
            }

            return overwritten;
        }

    }
}
