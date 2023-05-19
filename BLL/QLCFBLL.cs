using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
        public List<CBB_Item> GetCBB_TableName()
        {
            List<CBB_Item> result = new List<CBB_Item>();
            foreach (Table i in Return_Table())
            {
                result.Add(new CBB_Item
                {
                    Value = i.ID_Table,
                    Text = "Bàn "+ i.ID_Table.ToString()
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
        public bool Add_Account(string User_Account, string Name_Account, string Salary, string Adress, string Name_Role)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account))
            {
                return false;
            }
            else
            {
                s.Address = Adress;
                s.Name = Name_Account;
                s.Salary = Salary;
                s.UserName = User_Account;
                s.Password = Hash("123");
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
                s.Flag = true;
                db.Accounts.Add(s);
                db.SaveChanges();
                return true;
            }
            
            
        }
        public List<Bill_Detail> Return_Bill_Detail()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Bill_Detail.Where(p=>p.Flag==true).ToList();
        }
        
        public int SetIDTableByIDBill( int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var n = db.Bills.Where(p=>p.ID_Bill == idBill && p.Flag== true).FirstOrDefault();
            
            return Convert.ToInt32( n.ID_Table);
        }
       
      
        public string SetDateOrderByIDBill(int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();
            return Convert.ToString( s.Order_Day);
        }
        public string SetTimeDBill(int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();
            return s.Order_Time.ToString();
        }
        public void Add_Food(int idbill, string foodName)
        {
            PBL3Entities db = new PBL3Entities();
            var detail = db.Bill_Detail.FirstOrDefault();
            var s = db.Products.Where(p=>p.Name==foodName && p.Flag==true).FirstOrDefault();
            var b = db.Bills.Where(p => p.ID_Bill == idbill).FirstOrDefault();
            detail.ID_Product = s.ID_Product;
            detail.ID_Bill = idbill;
            detail.Flag = true;
            db.Bill_Detail.Add(detail);
            b.Price += s.Price;
            
            db.Bills.AddOrUpdate(b);
            db.SaveChanges();
        }
        public void Delete_Food(int idbill, string foodName)
        {
            PBL3Entities db = new PBL3Entities();          
            var s = db.Products.Where(p => p.Name == foodName && p.Flag ==true ).FirstOrDefault();
            var detail = db.Bill_Detail.Where(p=>p.ID_Product == s.ID_Product && p.ID_Bill == idbill).FirstOrDefault();
            detail.Flag = false;
            db.Bill_Detail.AddOrUpdate(detail);
            var b = db.Bills.Where(p => p.ID_Bill == idbill && p.Flag==true).FirstOrDefault();
            b.Price -= s.Price;
            db.Bills.AddOrUpdate(b);
            db.SaveChanges();
        }
        public string SetTotalBill(int idbill)
        {
            PBL3Entities db = new PBL3Entities();
            int sumprice = 0;
            foreach (Bill i in Return_Bill())
            {
                foreach (Bill_Detail j in Return_Bill_Detail())
                {
                    foreach (Product z in Return_Product())
                    {
                       if(idbill == i.ID_Bill && i.ID_Bill == j.ID_Bill&& j.ID_Product == z.ID_Product )
                      sumprice= sumprice+ Convert.ToInt32( z.Price ) * Convert.ToInt32(j.Quantity);
                       
                    }
                }
            }
            return sumprice.ToString();
        }
        public bool UpdateBill(int idbill,string txbTotal_Bill, string DateOrder, string txbTimeOrder, string cbb_Table)
        {
            PBL3Entities db = new PBL3Entities();
            var bil = db.Bills.Where(p => p.Flag == true && p.ID_Bill==idbill).FirstOrDefault();
             
            
            if (db.Bills.Any(p => p.Flag == true && p.ID_Bill == idbill))
            {
                bil.Price =Convert.ToInt32(txbTotal_Bill);
                bil.Order_Day = DateTime.ParseExact(DateOrder, "M/d/yyyy", CultureInfo.InvariantCulture);
                TimeSpan timeSpan = TimeSpan.Parse(txbTimeOrder);
                DateTime dateTime = DateTime.Today.Add(timeSpan);
                bil.ID_Table = Int32.Parse(new String(cbb_Table.Where(Char.IsDigit).ToArray()));
                db.Bills.AddOrUpdate(bil);
                db.SaveChanges();
                return true;
            }
            else 
                return false;
        }
        public List<Bill_DetailDatagridview> GetDGV_Bill_Detail(int id_Bill)
        {
            PBL3Entities db = new PBL3Entities();
            List<Bill_DetailDatagridview> result = new List<Bill_DetailDatagridview>();
            foreach (Bill i in Return_Bill())
            {
                foreach (Bill_Detail j in Return_Bill_Detail())
                {   
                    foreach(Product z in Return_Product())
                    {
                        int sumprice = 0;
                        if (Convert.ToInt32(j.Quantity) > 0)
                        {
                            for (int x = 1; x <= Convert.ToInt32(j.Quantity); x++)
                            {
                                sumprice += Convert.ToInt32(z.Price);
                            }
                        }
                        if ( id_Bill == j.ID_Bill && j.ID_Product == z.ID_Product && id_Bill == i.ID_Bill)
                            {
                                result.Add(new Bill_DetailDatagridview
                                {
                                    NameSP = z.Name,
                                    Quantity = Convert.ToInt32(j.Quantity),
                                    unit_price = Convert.ToInt32(z.Price),
                                    Total = sumprice
                                });

                            }                       
                    }
                }
            }
            return result;
        }

        public List<AccountDatagridview> GetDGV_Account_Search(string Account_Name)
        {
            PBL3Entities db = new PBL3Entities();
            List<AccountDatagridview> result = new List<AccountDatagridview>();
            foreach (Account i in Return_Account())
            {
                foreach (Role j in Return_Role())
                {
                    if (i.ID_Role == j.ID_Role)
                    {
                        if (i.Name.IndexOf(Account_Name) >= 0)
                            result.Add(new AccountDatagridview
                            {
                                UserName = i.UserName,
                                Name = i.Name,
                                Salary = i.Salary,
                                Address = i.Address,
                                Phone_Number = i.Phone_Number,
                                Name_Role = j.Role_Name
                            });
                    }
                }
            }
            return result;
        }
        public List<BillRevenue> GetDGV_Bill_Revenuve( DateTime dateTime)
        {
            PBL3Entities db = new PBL3Entities();
            List<BillRevenue> result = new List<BillRevenue>();
            foreach (Bill i in Return_Bill())
            {
                if ( i.Order_Day == dateTime && i.Flag == true && i.Pay_Status== true)
                {
                    result.Add(new BillRevenue
                    {
                       IdBill = i.ID_Bill,
                       Hour = i.Order_Time.ToString(),
                       SumPrice=Convert.ToInt32( SetTotalBill(i.ID_Bill)),
                       NameTable= "Bàn " + i.ID_Table.ToString()
                    });
                }
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
        public List<Bill> Return_Bill()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Bills.Where(p=> p.Flag== true).Select(p => p).ToList();
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

        public List<Revenue> Get_Revenue(DateTime? startDate, DateTime? endDate)
        {
            PBL3Entities db = new PBL3Entities();
            List<Revenue> result = new List<Revenue>();
            Dictionary<DateTime, int> dailySales = new Dictionary<DateTime, int>();
            List<Bill> bills = Return_Bill().OrderBy(b => b.Order_Day).ToList();
            foreach (Bill i in bills)
            {   


                if (startDate.Value.Date <= i.Order_Day.Value.Date && i.Order_Day.Value.Date <= endDate.Value.Date && i.Pay_Status == true)
                {
                    DateTime orderDay = Convert.ToDateTime(i.Order_Day);
                    int sales = Convert.ToInt32(i.Price);

                    if (dailySales.ContainsKey(orderDay))
                    {
                        dailySales[orderDay] += sales;
                    }
                    else
                    {
                        dailySales.Add(orderDay, sales);
                    }
                }
                  
            }
            
            foreach (KeyValuePair<DateTime, int> pair in dailySales)
            {   
                
                result.Add(new Revenue
                {
                    day = pair.Key.ToString("dd/MM/yyyy"),
                    price = Convert.ToInt32( pair.Value)
                }) ;
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
                            Name_Role = j.Role_Name
                        });
                    }
                }
            }
            return result;
        }      
        public bool UpdateAccount(string User_Account, string Name_Account, string Salary,string Phone, string Adress, string Name_Role)
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
               // s.Password = Hash("123");
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
        public bool UpdateAccount_PassWord(string User_Account, string PassWord)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.Where(p => p.UserName == User_Account).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account))
            {
               
                s.Password = Hash(PassWord);
                
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
                         
                s.Flag = false;
                db.Accounts.AddOrUpdate(s);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
         string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool CheckAcount(string User_Account, string PassWord_Account)
        {
            PBL3Entities db = new PBL3Entities();
            PassWord_Account = Hash(PassWord_Account);            
            if (db.Accounts.Any(p => p.UserName == User_Account && p.Password ==PassWord_Account && p.Flag == true))
            {
                return true;
            }
            return false;
        }
        public string SetNameAcount(string user)
        {   
            PBL3Entities db= new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();
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
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();
            
            return  s.Name ;
        }
        public string SetAcountAddress(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();

            return s.Address;
        }
        public string SetAcountPhone(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();

            return s.Phone_Number;
        }
        public string SetAcountSalary(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();

            return s.Salary;
        }

        public int CheckAcount_Role(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();
            return Convert.ToInt32( s.ID_Role.Value);
        }
    }
}
