using System;
using System.Collections.Generic;
using System.Data;

namespace SuperDevStore
{
    public class SubCategory
    {
        public static List<SubCategory> All()
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            DataTable subCategoriesDB = DB.Instance.ExecQuery("SELECT * FROM sub_categories");

            foreach (DataRow row in subCategoriesDB.Rows)
            {
                subCategories.Add(
                    new SubCategory(
                        int.Parse(row["id"].ToString()),
                        row["name"].ToString(),
                        bool.Parse(row["active"].ToString()),
                        int.Parse(row["category_id"].ToString())
                    )
                );
            }

            return subCategories;
        }

        public int id { get; }
        public string name { get; }
        public bool active { get; }
        public int categoryId { get; }

        public SubCategory(int Id, string Name, bool Active, int CategoryId)
        {
            id         = Id;
            name       = Name;
            active     = Active;
            categoryId = CategoryId;
        }
    }
}