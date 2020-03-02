using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class Task
    {
        private const float standardRate = 160;
        private const float premiumRate = 180;

        private string _taskID;
        public string taskID { get { return _taskID; } set { _taskID = value; } }

        private string _title;
        public string title { get { return _title; } set { _title = value; } }

        private string _description;
        public string description { get { return _description; } set { _description = value; } }

        private Category _category;
        public Category category { get { return _category; } set { _category = value; } }

        public string categoryName { get { return _category.categoryName; } }

        private Subcategory _subcategory;
        public Subcategory subcategory { get { return _subcategory; } set { _subcategory = value; } }

        private float _hours;
        public float hours { get { return _hours; } set { _hours = value; calculateCosts(); } }

        private List<TaskRow> _taskParts;
        public List<TaskRow> taskParts { get { return _taskParts; } }

        private float _partsCost;
        public float partsCost { get { calculateCosts();  return _partsCost; } }

        private float _standardTotal;
        public float standardTotal { get { return _standardTotal; } set { _standardTotal = value; } }

        private float _premiumTotal;
        public float premiumTotal { get { return _premiumTotal; } set { _premiumTotal = value; } }

        public Task()
        {
            _taskParts = new List<TaskRow>();
            hours = 0;
        }

        //this constructor clones a task from an existing task
        public Task(Task task)
        {
            taskID = task.taskID;
            title = task.title;
            description = task.description;
            category = task.category;
            subcategory = task.subcategory;
            _hours = task.hours;
            _taskParts = new List<TaskRow>();
            foreach(TaskRow row in task.taskParts)
            {
                taskParts.Add(new TaskRow(row));
            }
        }

        public void addComponent(TaskRow newComponent)
        {
            taskParts.Add(newComponent);
            calculateCosts();
        }

        public void addComponent(string name, string description, float unitCost)
        {
            TaskRow newComponent = new TaskRow(name, description, unitCost);
            taskParts.Add(newComponent);
            calculateCosts();
        }

        public void calculateCosts()
        {
            float cost = 0;
            
            for(int i = 0; i < taskParts.Count; i++)
            {
                cost += taskParts[i].partSubtotal;
            }

            _partsCost = cost;

            _standardTotal = _partsCost + (_hours * standardRate);

            _premiumTotal = _partsCost + (_hours * premiumRate);

        }
    }
}
