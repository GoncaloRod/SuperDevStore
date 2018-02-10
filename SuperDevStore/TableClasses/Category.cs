using System;
using System.Collections.Generic;
using System.Data;

namespace SuperDevStore
{
    public class Category
    {
        public static List<Category> All()
        {
            List<Category> categories = new List<Category>();

            DataTable categoriesDB = DB.Instance.ExecQuery("SELECT * FROM categories");

            foreach (DataRow row in categoriesDB.Rows)
            {
                categories.Add(
                    new Category(
                        int.Parse(row["id"].ToString()),
                        row["name"].ToString(),
                        bool.Parse(row["active"].ToString())
                    )
                );
            }

            return categories;
        }

        public int id { get; }
        public string name { get; }
        public bool active { get; }

        public Category(int Id, string Name, bool Active)
        {
            id     = Id;
            name   = Name;
            active = Active;
        }

        public List<SubCategory> SubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            DataTable subCategoriesDB = DB.Instance.ExecQuery($"SELECT * FROM sub_categories WHERE category_id = {id}");

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
    }
}