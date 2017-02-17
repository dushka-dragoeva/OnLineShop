using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.MVP.Sizes
{
  public  class SizeEventArgs
    {
        public SizeEventArgs(int id, string value)

        {
            this.Id = id;
            this.Value = value;
        }

        public int Id { get; set; }

        public string Value { get; set; }
    }
}
