using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3CodeDemo.BLL
{
    internal class QLCFBLL
    {
        public List<CBB_Item> GetCBB_TablePosition()
        {
            List<CBB_Item> result = new List<CBB_Item>();
            foreach (Table i in Return_Table())
            {
                result.Add(new CBB_Item
                {
                    Value = i.ID_Table,
                    Text = i.Position.ToString()
                    
                });
            }
            return result;
        }
        public List<Table> Return_Table()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Tables.Where(p=>p.Flag==true).Select(p => p).ToList();
        }
        public List<Account> Return_Account()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Accounts.Where(p=>p.Flag==true).Select(p => p).ToList();
        }
        public List<Role> Return_Role()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Roles.Select(p => p).ToList();
        }
        public List<TableDataGridView> GetDGV_Table()
        {
            PBL3Entities db = new PBL3Entities();
            List<TableDataGridView> result = new List<TableDataGridView>();
            foreach (Table i in Return_Table())
            {
                result.Add(new TableDataGridView
                {
                    ID_Table = i.ID_Table,
                    Status = Convert.ToBoolean(i.Status),
                    Position = i.Position
                });
            }
            return result;
        }
        public List<TableDataGridView> GetDGV_Table_Search(string Table_Name)
        {
            PBL3Entities db = new PBL3Entities();
            List<TableDataGridView> result = new List<TableDataGridView>();
            foreach (Table i in Return_Table())
            {
                if (i.ID_Table.ToString() == (Table_Name))
                {
                    result.Add(new TableDataGridView
                    {
                        ID_Table = i.ID_Table,
                        Status = Convert.ToBoolean(i.Status),
                        Position = i.Position
                    });
                }
            }
            return result;
        }
        public bool UpdateTable(int Old_ID_Table, int New_ID_Table, bool Status, string Position)
        {
            PBL3Entities db = new PBL3Entities();
            bool exists = db.Tables.Any(p => p.ID_Table == New_ID_Table);
            if(exists && Old_ID_Table != New_ID_Table) //ID nay da ton tai trong CSDL, nguoi dung phai nhap lai 
            {
                return false;
            }
            else
            {
                Table s = db.Tables.Where(p => p.ID_Table == Old_ID_Table).FirstOrDefault();
                s.ID_Table = New_ID_Table;
                s.Status = Status;
                s.Position = Position;
                db.SaveChanges();
                return true;
            }
        }
        public void DeleteTable(int ID_Table)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Tables.Where(p => p.ID_Table == ID_Table).FirstOrDefault();
            s.Flag = false;
            db.SaveChanges();
        }

        public List<AccountDatagridview> GetDGV_Account()
        {
            PBL3Entities db = new PBL3Entities();
            List<AccountDatagridview> result = new List<AccountDatagridview>();
            foreach (Account i in Return_Account())
            {
                foreach(Role j in Return_Role())
                {
                    if (i.ID_Role == j.ID_Role)
                    {
                        result.Add(new AccountDatagridview
                        {
                            UserName = i.UserName,
                            Name = i.Name,
                            Salary = i.Salary,
                            Address = i.Address,
                            Phone_Number = i.Phone_Number,
                            Password = i.Password,                            
                            Name_Role = j.Role_Name
                        });
                    }
                }
            }
            return result;
        }
    }
}
