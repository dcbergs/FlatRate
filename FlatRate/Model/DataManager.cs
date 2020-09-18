using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.Model
{
    class DataManager
    {
        private static readonly DataManager instance = new DataManager();

        public static DataSet Data { get; private set; }
        public static DataTable Categories { get { return Data.Tables["Categories"]; } }
        public static DataTable Subcategories { get { return Data.Tables["Subcategories"]; } }
        public static DataTable Parts { get { return Data.Tables["Parts"]; } }
        public static DataTable Tasks { get { return Data.Tables["Tasks"]; } }
        public static DataTable Tasks_Parts { get { return Data.Tables["Tasks_Parts"]; } }

        private DataManager()
        {
            Data = new DataSet();
            setupTables();
        }

        public static DataManager GetInstance()
        {
            return instance;
        }

        private void setupTables()
        {
            //define Tasks table
            DataTable tasks = Data.Tables.Add("Tasks");
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
            DataTable parts = Data.Tables.Add("Parts");
            DataColumn pkPartID = parts.Columns.Add("ID", typeof(string));
            parts.Columns.Add("Description", typeof(string));
            parts.Columns.Add("UnitPrice", typeof(float));
            parts.PrimaryKey = new DataColumn[] { pkPartID };

            //define Categories table
            DataTable categories = Data.Tables.Add("Categories");
            DataColumn pkCategoryID = categories.Columns.Add("ID", typeof(Int32));
            pkCategoryID.AutoIncrement = true;
            categories.Columns.Add("Title", typeof(string));
            categories.PrimaryKey = new DataColumn[] { pkCategoryID };

            //define subcategories table
            DataTable subcategories = Data.Tables.Add("Subcategories");
            DataColumn pkSubcategoryID = subcategories.Columns.Add("ID", typeof(Int32));
            pkSubcategoryID.AutoIncrement = true;
            subcategories.Columns.Add("Title", typeof(string));
            subcategories.Columns.Add("CategoryID", typeof(Int32));
            subcategories.PrimaryKey = new DataColumn[] { pkSubcategoryID };

            //define tasks_parts table
            DataTable tasksparts = Data.Tables.Add("Tasks_Parts");
            DataColumn fkTaskID = tasksparts.Columns.Add("TaskID", typeof(string));
            DataColumn fkPartID = tasksparts.Columns.Add("PartID", typeof(string));
            tasksparts.Columns.Add("Quantity", typeof(float));
            tasksparts.PrimaryKey = new DataColumn[] { fkTaskID, fkPartID };

            //Tasks.CategoryID -> Categories.ID relationship
            DataRelation taskCategoryRelation = Data.Relations.Add("TaskCategories",
                Data.Tables["Categories"].Columns["ID"],
                Data.Tables["Tasks"].Columns["CategoryID"]);

            //Tasks.SubcategoryID -> Subcategories.ID relationship
            DataRelation taskSubcategoryRelation = Data.Relations.Add("TaskSubcategories",
                Data.Tables["Subcategories"].Columns["ID"],
                Data.Tables["Tasks"].Columns["SubcategoryID"]);

            //Subcategories.CategoryID -> Categories.ID relationship
            DataRelation subcategoryCategoryRelation = Data.Relations.Add("SubcategoryCategories",
                Data.Tables["Categories"].Columns["ID"],
                Data.Tables["Subcategories"].Columns["CategoryID"]);

            //Tasks_Parts.TaskID -> Tasks.ID relationship
            DataRelation taskPartsTaskRelation = Data.Relations.Add("taskPartsTasks",
                Data.Tables["Tasks"].Columns["ID"],
                Data.Tables["Tasks_Parts"].Columns["TaskID"]);

            //Tasks_Parts.PartID -> Parts.ID relationship
            DataRelation taskPartsPartRelation = Data.Relations.Add("taskPartsParts",
                Data.Tables["Parts"].Columns["ID"],
                Data.Tables["Tasks_Parts"].Columns["PartID"]);

        }

        public List<TaskSummary> GetTaskSummaries()
        {
            return
                (from task in Tasks.AsEnumerable()
                 join taskpart in Tasks_Parts.AsEnumerable()
                 on task.Field<String>("ID") equals taskpart.Field<String>("TaskID") into tp
                 select new TaskSummary {
                     Id = task.Field<String>("ID"),
                     Title = task.Field<String>("Title"),
                     Description = task.Field<String>("Description"),
                     CategoryName = task.GetParentRow("taskCategories").Field<String>("Title"),
                     SubcategoryName = task.GetParentRow("taskSubcategories").Field<String>("Title"),
                     Hours = task.Field<float>("Hours"),
                     StandardTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.STANDARD_RATE) + task.Field<float>("StdAddOn")),
                     PremiumTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.PREMIUM_RATE) + task.Field<float>("PremAddOn"))
                    }
                 ).ToList();
        }

        public List<TaskSummary> GetTaskSummariesByCategoryId(int id)
        {
            return
                (from task in Tasks.AsEnumerable()
                 where task.Field<Int32>("CategoryId") == id
                 join taskpart in Tasks_Parts.AsEnumerable()
                 on task.Field<String>("ID") equals taskpart.Field<String>("TaskID") into tp
                 select new TaskSummary
                 {
                     Id = task.Field<String>("ID"),
                     Title = task.Field<String>("Title"),
                     Description = task.Field<String>("Description"),
                     CategoryName = task.GetParentRow("taskCategories").Field<String>("Title"),
                     SubcategoryName = task.GetParentRow("taskSubcategories").Field<String>("Title"),
                     Hours = task.Field<float>("Hours"),
                     StandardTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.STANDARD_RATE) + task.Field<float>("StdAddOn")),
                     PremiumTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.PREMIUM_RATE) + task.Field<float>("PremAddOn"))
                 }
                 ).ToList();
        }

        public List<TaskSummary> GetTaskSummariesBySubcategoryId(int id)
        {
            return
                (from task in Tasks.AsEnumerable()
                 where task.Field<Int32>("SubcategoryId") == id
                 join taskpart in Data.Tables["Tasks_Parts"].AsEnumerable()
                 on task.Field<String>("ID") equals taskpart.Field<String>("TaskID") into tp
                 select new TaskSummary
                 {
                     Id = task.Field<String>("ID"),
                     Title = task.Field<String>("Title"),
                     Description = task.Field<String>("Description"),
                     CategoryName = task.GetParentRow("taskCategories").Field<String>("Title"),
                     SubcategoryName = task.GetParentRow("taskSubcategories").Field<String>("Title"),
                     Hours = task.Field<float>("Hours"),
                     StandardTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.STANDARD_RATE) + task.Field<float>("StdAddOn")),
                     PremiumTotal = Math.Ceiling(tp.Sum(x => x.GetParentRow("taskPartsParts").Field<float>("UnitPrice") * x.Field<float>("Quantity")) + (task.Field<float>("Hours") * Program.PREMIUM_RATE) + task.Field<float>("PremAddOn"))
                 }
                 ).ToList();
        }

        public void ReadXML(String filepath)
        {
            Data.ReadXml(filepath);
        }

        public void WriteXML(String filepath)
        {
            Data.WriteXml(filepath);
        }

        public void LoadXML(String filepath)
        {
            Data.EnforceConstraints = false;
            Data = new DataSet();
            setupTables();
            Data.ReadXml(filepath);
            Data.EnforceConstraints = true;
        }

        public void AddPart(Part part)
        {
            //if it doesn't contain ID already,
            if (Data.Tables["Parts"].Rows.Find(part.Id) == null)
            {
                DataRow newPart = Data.Tables["Parts"].NewRow();
                newPart["ID"] = part.Id;
                newPart["Description"] = part.Description;
                newPart["UnitPrice"] = part.UnitPrice;
                Data.Tables["Parts"].Rows.Add(newPart);
            }
            else
            {
                DataRow row = Data.Tables["Parts"].Rows.Find(part.Id);
                row["Description"] = part.Description;
                row["UnitPrice"] = part.UnitPrice;
            }
        }

        public void AddSubcategory(Subcategory subcategory)
        {
            DataRow addRow = Subcategories.NewRow();
            addRow["Title"] = subcategory.Title;
            addRow["CategoryID"] = subcategory.CategoryId;
            Subcategories.Rows.Add(addRow);
        }

        public List<Subcategory> GetSubcategoriesByCategoryId(int id)
        {
            List<Subcategory> subcategories = new List<Subcategory>();
            var subcatQuery =
                from subcategory in Subcategories.AsEnumerable()
                where subcategory.Field<Int32>("CategoryID") == id
                select subcategory;
            foreach(DataRow subcat in subcatQuery)
            {
                Subcategory newSubcat = new Subcategory
                {
                    Id = subcat.Field<Int32>("ID"),
                    Title = subcat.Field<String>("Title"),
                    CategoryId = subcat.Field<Int32>("CategoryID"),
                };
                subcategories.Add(newSubcat);
            }
            return subcategories;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            var categoryQuery =
                from category in Categories.AsEnumerable()
                select category;
            foreach(var category in categoryQuery)
            {
                Category newCat = new Category
                {
                    Id = category.Field<Int32>("ID"),
                    Title = category.Field<String>("Title"),
                };
                categories.Add(newCat);
            }
            return categories;
        }

        public bool IsTask(String Id)
        {
            return Tasks.Rows.Contains(Id);
        }

        public void UpdateTaskWithoutParts(String id, MultiTaskEditDescriptor changes)
        {
            if (IsTask(id))
            {
                DataRow row = Tasks.Rows.Find(id);
                if (changes.IsCategoryChanging)
                {
                    row["CategoryID"] = changes.CategoryId;
                    row["SubcategoryID"] = changes.SubcategoryId;
                }
                if (changes.IsHoursChanging)
                {
                    if (changes.IsHoursAdditive)
                    {
                        if(row.Field<float>("Hours") + changes.Hours < 0)
                        {
                            row["Hours"] = 0.0f;
                        }
                        else
                        {
                            row["Hours"] = row.Field<float>("Hours") + changes.Hours;
                        }
                    }
                    else
                    {
                        if(changes.Hours < 0)
                        {
                            row["Hours"] = 0.0f;
                        }
                        else
                        {
                            row["Hours"] = changes.Hours;
                        }
                    }
                }
                if (changes.IsStandardChanging)
                {
                    if (changes.IsStandardAdditive)
                    {
                        row["StdAddOn"] = row.Field<float>("StdAddOn") + changes.StandardAddOn;
                    }
                    else
                    {
                        row["StdAddOn"] = changes.StandardAddOn;
                    }
                }
                if (changes.IsPremiumChanging)
                {
                    if (changes.IsPremiumAdditive)
                    {
                         row["PremAddOn"] = row.Field<float>("PremAddOn") + changes.PremiumAddOn;
                    }
                    else
                    {
                        row["PremAddOn"] = changes.PremiumAddOn;
                    }
                }
            }
        }

        public void AddOrUpdateTask(Task task, List<TaskRow> parts)
        {
            DataRow row;
            bool isUpdate = IsTask(task.Id);
            //row already exists, so update it
            if (isUpdate)
            {
                row = Tasks.Rows.Find(task.Id);
            }
            //row does not yet exist, create it
            else
            {
                row = Tasks.NewRow();
                row["ID"] = task.Id;
            }

            row["Title"] = task.Title;
            row["Description"] = task.Description;
            row["CategoryID"] = task.CategoryId;
            row["SubcategoryID"] = task.SubcategoryId;
            row["Hours"] = task.Hours;
            row["StdAddOn"] = task.StandardAddOn;
            row["PremAddOn"] = task.PremiumAddOn;

            if (!isUpdate)
            {
                Tasks.Rows.Add(row);
            }

            //also edit tasks_parts
            //remove prior associations with this Task.ID, if any
            var toRemove =
                from taskpart in Tasks_Parts.AsEnumerable()
                where taskpart.Field<string>("TaskID") == task.Id
                select taskpart;
            foreach (var removeRow in toRemove.ToList())
            {
                removeRow.Delete();
            }
            //add new associations with this Task.ID
            foreach (TaskRow part in parts)
            {
                DataRow newPart = Tasks_Parts.NewRow();
                newPart["TaskID"] = task.Id;
                newPart["PartID"] = part.id;
                newPart["Quantity"] = part.quantity;
                Tasks_Parts.Rows.Add(newPart);
            }
            Tasks.AcceptChanges();
            Tasks_Parts.AcceptChanges();
        }

        public Task GetTaskById(String id)
        {
            if (!Tasks.Rows.Contains(id))
            {
                throw new ArgumentException("task with such id does not exist");
            }
            DataRow row = Tasks.Rows.Find(id);
            Task editTask = new Task
            {
                Id = id,
                Title = row.Field<String>("Title"),
                Description = row.Field<String>("Description"),
                CategoryId = row.Field<Int32>("CategoryID"),
                SubcategoryId = row.Field<Int32>("SubcategoryID"),
                Hours = row.Field<float>("Hours"),
                StandardAddOn = row.Field<float>("StdAddOn"),
                PremiumAddOn = row.Field<float>("PremAddOn"),
            };
            return editTask;
        }

        public List<String> GetTaskIDsUsingThisPart(String partId)
        {
            List<String> tasks = new List<String>();
            var query =
                from taskparts in Tasks_Parts.AsEnumerable()
                where taskparts.Field<String>("PartID") == partId
                select new
                {
                    id = taskparts.Field<String>("TaskID")
                };
            foreach(var task in query)
            {
                tasks.Add(task.id);
            }
            return tasks;
        }

        public void DeleteTask(String id)
        {
            //query Tasks_Parts for removal
            EnumerableRowCollection<DataRow> taskspartsquery =
                from removalRow in Tasks_Parts.AsEnumerable()
                where removalRow.Field<String>("TaskID") == id
                select removalRow;

            Tasks_Parts.AcceptChanges();

            foreach (DataRow taskspartsrow in taskspartsquery)
            {
                taskspartsrow.Delete();
            }
            Tasks_Parts.AcceptChanges();

            //remove the task itself
            Tasks.Rows.Find(id).Delete();
            Tasks.AcceptChanges();
            Data.AcceptChanges();
        }

        public void DeleteSubcategory(int id)
        {
            DeleteTasksFromSummaries(GetTaskSummariesBySubcategoryId(id));
            Subcategories.Rows.Find(id).Delete();
            Subcategories.AcceptChanges();
        }

        public void DeleteTasksFromSummaries(List<TaskSummary> tasks) {
            foreach (TaskSummary task in tasks)
            {
                DeleteTask(task.Id);
            }
        }

        public void DeleteSubcategories(List<Subcategory> subcategories)
        {
            foreach(Subcategory sub in subcategories)
            {
                DeleteSubcategory(sub.Id);
            }
        }

        public DataView GetSubcategoriesViewByCategory(int categoryId)
        {
            EnumerableRowCollection<DataRow> subcategoryQuery =
                from subcategory in Subcategories.AsEnumerable()
                where subcategory.Field<Int32>("CategoryID") == categoryId
                select subcategory;

            return subcategoryQuery.AsDataView();
        }

        public void DeleteCategoryById(int id)
        {
            DeleteSubcategories(GetSubcategoriesByCategoryId(id));
            Categories.Rows.Find(id).Delete();
            Categories.AcceptChanges();
        }

        public List<TaskRow> TemporaryPartsByTask(String taskId)
        {
            List<TaskRow> temporaryParts = new List<TaskRow>();
            //select all rows from tasks_parts belonging to taskID
            var taskpartsquery =
                from taskparts in Tasks_Parts.AsEnumerable()
                where taskparts.Field<String>("TaskID") == taskId
                select taskparts;

            //for each row, extract data and make a new TaskRow object
            foreach (DataRow taskpart in taskpartsquery)
            {
                string newid = taskpart.Field<String>("PartID");
                string newDescription = taskpart.GetParentRow("taskPartsParts").Field<String>("Description");
                float newCost = taskpart.GetParentRow("taskPartsParts").Field<float>("UnitPrice");
                float newQuantity = taskpart.Field<float>("Quantity");
                TaskRow newPart = new TaskRow(newid, newDescription, newCost, newQuantity);

                temporaryParts.Add(newPart);
            }

            return temporaryParts;
        }

        public void FilterParts(String searchTerm)
        {
            Parts.DefaultView.RowFilter = "ID LIKE '%" + searchTerm + "%'";
            Parts.DefaultView.RowFilter += "OR Description LIKE '%" + searchTerm + "%'";
        }

        public void AddCategory(String categoryName)
        {
            DataRow row = Categories.NewRow();
            row["Title"] = categoryName;
            Categories.Rows.Add(row);
        }

        public void DeletePartById(String partId)
        {
            //query Tasks_Parts for removal
            EnumerableRowCollection<DataRow> taskspartsquery =
                from removalRow in Tasks_Parts.AsEnumerable()
                where removalRow.Field<String>("PartID") == partId
                select removalRow;

            Tasks_Parts.AcceptChanges();

            foreach (DataRow taskspartsrow in taskspartsquery)
            {
                taskspartsrow.Delete();
            }
            Tasks_Parts.AcceptChanges();

            //remove the part itself
            Parts.Rows.Find(partId).Delete();
            Parts.AcceptChanges();
        }

        public void ClearAllData()
        {
            Data = new DataSet();
            setupTables();
        }
    }
}
