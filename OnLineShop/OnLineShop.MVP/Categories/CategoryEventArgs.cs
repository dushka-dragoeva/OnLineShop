using System;

namespace OnLineShop.MVP.Categories
{
    public class CategoryEventArgs : EventArgs
    {
        public CategoryEventArgs(int id, string name)

        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
