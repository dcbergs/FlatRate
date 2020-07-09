using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class Schema
    {
        private DataSet data;

        public Schema(DataSet data)
        {
            this.data = data;
        }

        public void setupData()
        {
            //define Tasks table
            DataTable tasks = data.Tables.Add("Tasks");

            DataColumn pkTaskID = tasks.Columns.Add("ID", typeof(string));
            tasks.Columns.Add("Title", typeof(string));
            tasks.Columns.Add("Description", typeof(string));
            tasks.Columns.Add("CategoryID", typeof(Int32));
            tasks.Columns.Add("SubcategoryID", typeof(Int32));
            tasks.Columns.Add("Hours", typeof(float));
            tasks.Columns.Add("StdAddOn", typeof(float));
            tasks.Columns.Add("PremAddOn", typeof(float));
            tasks.PrimaryKey = new DataColumn[] { pkTaskID };

            //define parts table
            DataTable parts = data.Tables.Add("Parts");
            DataColumn pkPartID = parts.Columns.Add("ID", typeof(string));
            parts.Columns.Add("Description", typeof(string));
            parts.Columns.Add("UnitPrice", typeof(float));
            parts.PrimaryKey = new DataColumn[] { pkPartID };

            //define Categories table
            DataTable categories = data.Tables.Add("Categories");
            DataColumn pkCategoryID = categories.Columns.Add("ID", typeof(Int32));
            pkCategoryID.AutoIncrement = true;
            categories.Columns.Add("Title", typeof(string));
            categories.PrimaryKey = new DataColumn[] { pkCategoryID };

            //define subcategories table
            DataTable subcategories = data.Tables.Add("Subcategories");
            DataColumn pkSubcategoryID = subcategories.Columns.Add("ID", typeof(Int32));
            pkSubcategoryID.AutoIncrement = true;
            subcategories.Columns.Add("Title", typeof(string));
            subcategories.Columns.Add("CategoryID", typeof(Int32));
            subcategories.PrimaryKey = new DataColumn[] { pkSubcategoryID };

            //define tasks_parts table
            DataTable tasksparts = data.Tables.Add("Tasks_Parts");
            DataColumn fkTaskID = tasksparts.Columns.Add("TaskID", typeof(string));
            DataColumn fkPartID = tasksparts.Columns.Add("PartID", typeof(string));
            tasksparts.Columns.Add("Quantity", typeof(float));
            tasksparts.PrimaryKey = new DataColumn[] { fkTaskID, fkPartID };

            //Tasks.CategoryID -> Categories.ID relationship
            DataRelation taskCategoryRelation = data.Relations.Add("TaskCategories",
                data.Tables["Categories"].Columns["ID"],
                data.Tables["Tasks"].Columns["CategoryID"]);

            //Tasks.SubcategoryID -> Subcategories.ID relationship
            DataRelation taskSubcategoryRelation = data.Relations.Add("TaskSubcategories",
                data.Tables["Subcategories"].Columns["ID"],
                data.Tables["Tasks"].Columns["SubcategoryID"]);

            //Subcategories.CategoryID -> Categories.ID relationship
            DataRelation subcategoryCategoryRelation = data.Relations.Add("SubcategoryCategories",
                data.Tables["Categories"].Columns["ID"],
                data.Tables["Subcategories"].Columns["CategoryID"]);

            //Tasks_Parts.TaskID -> Tasks.ID relationship
            DataRelation taskPartsTaskRelation = data.Relations.Add("taskPartsTasks",
                data.Tables["Tasks"].Columns["ID"],
                data.Tables["Tasks_Parts"].Columns["TaskID"]);

            //Tasks_Parts.PartID -> Parts.ID relationship
            DataRelation taskPartsPartRelation = data.Relations.Add("taskPartsParts",
                data.Tables["Parts"].Columns["ID"],
                data.Tables["Tasks_Parts"].Columns["PartID"]);


        }
    }
}
