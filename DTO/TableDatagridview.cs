using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3CodeDemo.DTO
{
    public class TableDataGridView
    {
        public int ID_Table { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Position { get; set; }
        /*public TableDataGridView(int ID_Table, bool Status, string Position)
        {
            this.ID_Table = ID_Table;
            this.Status = Status;
            this.Position = Position;
        }*/
    }
}
