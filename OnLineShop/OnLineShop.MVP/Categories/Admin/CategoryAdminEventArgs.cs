using System;

namespace OnLineShop.MVP.Categories.Admin
{
    public class CategoryAdminEventArgs : EventArgs
    {
        public CategoryAdminEventArgs(int id, string name)

        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
