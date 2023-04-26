using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public List<CBB_Item> GetCBB_Category()
        {
            List<CBB_Item> result = new List<CBB_Item>();
            foreach (Category i in Return_Category())
            {
                result.Add(new CBB_Item
                {
                    Value = i.ID_Category,
                    Text = i.Category_Name.ToString()

                });
            }
            return result;
        }
        public List<CBB_Item> GetCBB_Food( int idcategory)
        {
            List<CBB_Item> result = new List<CBB_Item>();
            foreach (Product i in Return_Product())
            {
                foreach (Category j in Return_Category())
                {
                   
                        if (idcategory == i.ID_Category && j.ID_Category==i.ID_Category)
                        {
                            result.Add(new CBB_Item
                            {
                                Value = i.ID_Product,
                                Text = i.Name.ToString()
                            });
                        }
                }
            }
            return result;
        }
        public List<Category> Return_Category()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Categories.Where(p => p.Flag == true).Select(p => p).ToList();
        }
        public List<Product> Return_Product()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Products.Where(p => p.Flag == true).Select(p => p).ToList();
        }
        public bool Add_Account(string User_Account, string Name_Account, string Salary, string Adress, string PassWord, string Name_Role)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.FirstOrDefault();
            s.Address = Adress;
            s.Name = Name_Account;
            s.Salary = Salary;
            s.UserName = User_Account;
            s.Password = PassWord;
            if (Name_Role == "Quản lý")
            {
                s.ID_Role = 1;
            }
            if (Name_Role == "Thu ngân")
            {
                s.ID_Role = 2;
            }
            if (Name_Role == "Nhân Viên")
            {
                s.ID_Role = 3;
            }
            s.Flag=true;
            db.Accounts.Add(s);
            db.SaveChanges();
            return true;
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
        public bool UpdateAccount(string User_Account, string Name_Account, string Salary,string Phone, string Adress, string PassWord, string Name_Role)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.Where(p => p.UserName == User_Account).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account))
            {
                s.Address = Adress;
                s.Name = Name_Account;
                s.Salary = Salary;
                s.Phone_Number= Phone;
                s.UserName = User_Account;
                s.Password = PassWord;
                if (Name_Role == "Quản lý" || Name_Role=="1")
                {
                    s.ID_Role = 1;
                }
                if (Name_Role == "Thu ngân" || Name_Role =="2")
                {
                    s.ID_Role = 2;
                }
                if (Name_Role == "Nhân viên" || Name_Role == "3")
                {
                    s.ID_Role = 3;
                }
              
                db.Accounts.AddOrUpdate(s);
                db.SaveChanges();
                return true;
            }
            else return false;


        }
        public bool DeleteAccount(string User_Account)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.Where(p => p.UserName == User_Account).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account))
            {
                s.Address ="";
                s.Name = "";
                s.Salary = "";
                s.UserName = "";
                s.Password = "";
                s.ID_Role = 0;                
                s.Flag = false;
                db.Accounts.AddOrUpdate(s);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool CheckAcount(string User_Account, string PassWord_Account)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.Where(p => p.UserName == User_Account).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account && p.Password ==PassWord_Account))
            {
                return true;
            }
            return false;
        }
        public string SetNameAcount(string user)
        {   
            PBL3Entities db= new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();
            string rol="";
            if(s.ID_Role== 1)
            {
                rol= "Quản lý";
            }
            if (s.ID_Role == 2)
            {
                rol = "Thu ngân";
            }
            if (s.ID_Role == 3)
            {
                rol = "Nhân viên";
            }
            
            return "Quản lý bàn - "+ s.Name + " - " + rol;
        }
        public string SetAcountName(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();
            
            return  s.Name ;
        }
        public string SetAcountAddress(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();

            return s.Address;
        }
        public string SetAcountPhone(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();

            return s.Phone_Number;
        }
        public string SetAcountSalary(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();

            return s.Salary;
        }

        public int CheckAcount_Role(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user).FirstOrDefault();
            return Convert.ToInt32( s.ID_Role.Value);
        }
    }
}
