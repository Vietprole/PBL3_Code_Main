using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3CodeDemo.DTO
{
    public class CBB_Item
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
