using System;

namespace OnLineShop.MVP.Categories
{
    public class CategoryEventArgs : EventArgs
    {
        public CategoryEventArgs(string name, int id)

        {
            this.Name = name;
            this.Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
