using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class App : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate navbar
            string navHtml = "";

            foreach (var category in Category.All())
            {
                navHtml += "<li class='nav-item'>";
                navHtml += "    <a class='nav-link dropdown-toggle' href='' id='navbarDropdown' role='button' data-toggle='dropdown'>";
                navHtml += "        " + category.name;
                navHtml += "    </a>";
                navHtml += "    <div class='dropdown-menu'>";

                foreach (var subCategory in category.SubCategories())
                {
                    navHtml += "        <a class='dropdown-item' href='ShowProducts?subCat=" + subCategory.id + "'>" + subCategory.name + "</a>";
                }

                navHtml += "    </div>";
                navHtml += "</li>";
            }

            navItems.InnerHtml = navHtml;
        }
    }
}