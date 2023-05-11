using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
                    Text = "Bàn " + i.ID_Table.ToString()

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
        public List<CBB_Item> GetCBB_Food(int idcategory)
        {
            List<CBB_Item> result = new List<CBB_Item>();
            foreach (Product i in Return_Product())
            {
                foreach (Category j in Return_Category())
                {

                    if (idcategory == i.ID_Category && j.ID_Category == i.ID_Category)
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
            return db.Bill_Detail.Where(p => p.Flag == true).ToList();
        }

        public string SetNameTableByIDBill(int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var n = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();

            return "Bàn " + n.ID_Table;
        }
        public bool CheckStatusByIdBll(int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();
            return Convert.ToBoolean(s.Pay_Status);
        }
        public string SetDateOrderByIDBill(int idBill)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();
            return Convert.ToString(s.Order_Day);
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
            var s = db.Products.Where(p => p.Name == foodName && p.Flag == true).FirstOrDefault();
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

            var s = db.Products.Where(p => p.Name == foodName && p.Flag == true).FirstOrDefault();

            var detail = db.Bill_Detail.Where(p => p.ID_Product == s.ID_Product && p.ID_Bill == idbill).FirstOrDefault();

            detail.Flag = false;
            db.Bill_Detail.AddOrUpdate(detail);
            var b = db.Bills.Where(p => p.ID_Bill == idbill && p.Flag == true).FirstOrDefault();
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
                        if (idbill == i.ID_Bill && i.ID_Bill == j.ID_Bill && j.ID_Product == z.ID_Product)
                            sumprice = sumprice + Convert.ToInt32(z.Price) * Convert.ToInt32(j.Quantity);

                    }
                }
            }
            return sumprice.ToString();
        }
        public bool UpdateBill(int idbill, string txbTotal_Bill, string DateOrder, string txbTimeOrder, string cbb_Table, bool radioButtonTrue)
        {
            PBL3Entities db = new PBL3Entities();
            var bil = db.Bills.Where(p => p.Flag == true && p.ID_Bill == idbill).FirstOrDefault();


            if (db.Bills.Any(p => p.Flag == true && p.ID_Bill == idbill))
            {
                bil.Price = Convert.ToInt32(txbTotal_Bill);
                bil.Order_Day = DateTime.ParseExact(DateOrder, "M/d/yyyy", CultureInfo.InvariantCulture);
                TimeSpan timeSpan = TimeSpan.Parse(txbTimeOrder);
                DateTime dateTime = DateTime.Today.Add(timeSpan);
                // bil.Order_Time= ;
                bil.Pay_Status = radioButtonTrue;
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
                    foreach (Product z in Return_Product())
                    {
                        int sumprice = 0;
                        if (Convert.ToInt32(j.Quantity) > 0)
                        {
                            for (int x = 1; x <= Convert.ToInt32(j.Quantity); x++)
                            {
                                sumprice += Convert.ToInt32(z.Price);
                            }
                        }
                        if (id_Bill == j.ID_Bill && j.ID_Product == z.ID_Product && id_Bill == i.ID_Bill)
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
        public List<BillRevenue> GetDGV_Bill_Revenuve(DateTime dateTime)
        {
            PBL3Entities db = new PBL3Entities();
            List<BillRevenue> result = new List<BillRevenue>();
            foreach (Bill i in Return_Bill())
            {
                if (i.Order_Day == dateTime && i.Flag == true && i.Pay_Status == true)
                {
                    result.Add(new BillRevenue
                    {
                        IdBill = i.ID_Bill,
                        Hour = i.Order_Time.ToString(),
                        SumPrice = Convert.ToInt32(SetTotalBill(i.ID_Bill)),
                        NameTable = "Bàn " + i.ID_Table.ToString()
                    });
                }
            }
            return result;
        }
        public List<Table> Return_Table()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Tables.Where(p => p.Flag == true).Select(p => p).ToList();
        }
        public List<Account> Return_Account()
        {
            PBL3Entities db = new PBL3Entities();

            return db.Accounts.Where(p => p.Flag == true).Select(p => p).ToList();
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
                    Name = i.Table_Name.ToString(),
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
            foreach (Bill i in Return_Bill())
            {
                if (startDate.Value.Date <= i.Order_Day.Value.Date && i.Order_Day.Value.Date <= endDate.Value.Date)
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
                    price = Convert.ToInt32(pair.Value)
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
                if (i.Table_Name.ToString().Contains(Table_Name))
                {
                    result.Add(new TableDataGridView
                    {
                        ID_Table = i.ID_Table,
                        Name = i.Table_Name,
                        Status = Convert.ToBoolean(i.Status),
                        Position = i.Position
                    });
                }
            }
            return result;
        }
        public bool UpdateTable(int ID_Table, string Table_Name, bool Status, string Position)
        {
            PBL3Entities db = new PBL3Entities();
            Table s = db.Tables.Where(p => p.ID_Table == ID_Table).FirstOrDefault();
            s.Table_Name = Table_Name;
            s.Status = false;
            s.Position = Position;
            db.SaveChanges();
            return true;

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
                foreach (Role j in Return_Role())
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
        public bool UpdateAccount(string User_Account, string Name_Account, string Salary, string Phone, string Adress, string Name_Role)
        {
            PBL3Entities db = new PBL3Entities();
            Account s = db.Accounts.Where(p => p.UserName == User_Account).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account))
            {
                s.Address = Adress;
                s.Name = Name_Account;
                s.Salary = Salary;
                s.Phone_Number = Phone;
                s.UserName = User_Account;
                s.Password = Hash("123");
                if (Name_Role == "Quản lý" || Name_Role == "1")
                {
                    s.ID_Role = 1;
                }
                if (Name_Role == "Thu ngân" || Name_Role == "2")
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

        //private string HashPassword(string passWord)
        //{
        //    byte[] salt;
        //    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        //    var pbkdf2 = new Rfc2898DeriveBytes(passWord, salt, 100000);
        //    byte[] hash = pbkdf2.GetBytes(20);
        //    byte[] hashBytes = new byte[36];
        //    Array.Copy(salt, 0, hashBytes, 0, 16);
        //    Array.Copy(hash, 0, hashBytes, 16, 20);
        //    string savedPasswordHash = Convert.ToBase64String(hashBytes);
        //    return savedPasswordHash;
        //}

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
            Account s = db.Accounts.Where(p => p.UserName == User_Account && p.Flag == true).FirstOrDefault();
            if (db.Accounts.Any(p => p.UserName == User_Account && p.Password == PassWord_Account && p.Flag == true))
            {
                return true;
            }
            return false;
        }
        public string SetNameAcount(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();
            string rol = "";
            if (s.ID_Role == 1)
            {
                rol = "Quản lý";
            }
            if (s.ID_Role == 2)
            {
                rol = "Thu ngân";
            }
            if (s.ID_Role == 3)
            {
                rol = "Nhân viên";
            }

            return "Quản lý bàn - " + s.Name + " - " + rol;
        }
        public string SetAcountName(string user)
        {
            PBL3Entities db = new PBL3Entities();
            var s = db.Accounts.Where(p => p.UserName == user && p.Flag == true).FirstOrDefault();

            return s.Name;
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
            return Convert.ToInt32(s.ID_Role.Value);
        }
        public List<TableDataGridView> LoadTable_Button()
        {
            List<TableDataGridView> list_table = new List<TableDataGridView>();
            foreach (Table i in Return_Table())
            {
                list_table.Add(new TableDataGridView
                {
                    ID_Table = i.ID_Table,
                    Name = i.Table_Name,
                    Status = Convert.ToBoolean(i.Status),
                    Position = i.Position
                });
            }

            return list_table;
        }
        public string Return_ProductName(int ID_Product)
        {
            PBL3Entities db = new PBL3Entities();
            string result = "";
            List<Product> list_Product = new List<Product>();
            list_Product = db.Products.Where(p => p.ID_Product == ID_Product).Select(p => p).ToList();
            foreach (Product i in list_Product)
            {
                result = i.Name.ToString();
            }
            return result;
        }
        public int Return_ProductId(string ProductName)
        {
            PBL3Entities db = new PBL3Entities();
            int result = 0;
            List<Product> list_Product = new List<Product>();
            list_Product = db.Products.Where(p => p.Name == ProductName && p.Flag == true).Select(p => p).ToList();
            foreach (Product i in list_Product)
            {
                result = i.ID_Product;
            }
            return result;
        }

        public int Return_ProductPrice(int ID_Product)
        {
            PBL3Entities db = new PBL3Entities();
            int result = 0;
            List<Product> list_Product = new List<Product>();
            list_Product = db.Products.Where(p => p.ID_Product == ID_Product).Select(p => p).ToList();
            foreach (Product i in list_Product)
            {
                result = Convert.ToInt32(i.Price);
            }
            return result;
        }
        public List<Bill> Return_Bill()
        {
            PBL3Entities db = new PBL3Entities();
            return db.Bills.Where(p => p.Flag == true).Select(p => p).ToList();
        }
        public List<Bill_Detail> Return_BillDetails(int id_Bill)
        {   //Tra ve cac Bill_Detail cua Bill co id la id_Bill
            PBL3Entities db = new PBL3Entities();
            //MessageBox.Show(id_Bill.ToString());
            return db.Bill_Detail.Where(p => p.ID_Bill == id_Bill).Select(p => p).ToList();
        }
        public List<Bill_DetailDatagridview> Get_Bill_Detail(int id_Table)
        {
            List<Bill_DetailDatagridview> result = new List<Bill_DetailDatagridview>();
            int id_Bill = 0;
            foreach (Bill i in Return_Bill())
            {
                if (i.Pay_Status == false && i.ID_Table == id_Table)
                {//Chưa thanh toán 

                    id_Bill = i.ID_Bill;
                    break;
                }
            }
            foreach (Bill_Detail i in Return_BillDetails(id_Bill))
            {
                //MessageBox.Show(i.ID_Product.ToString());
                if (i.Flag == true)
                {
                    result.Add(new Bill_DetailDatagridview
                    {
                        NameSP = Return_ProductName(Convert.ToInt32(i.ID_Product)),
                        Quantity = Convert.ToInt32(i.Quantity),
                        unit_price = Return_ProductPrice(Convert.ToInt32(i.ID_Product))

                    });
                }
                else
                {
                }


            }
            return result;
        }
        public void Add_Food_ToTable(int idTable, string foodName, int Quantity)
        {
            PBL3Entities db = new PBL3Entities();
            int id_Bill = 0;
            foreach (Bill i in Return_Bill())
            {
                if (i.Pay_Status == false && i.ID_Table == idTable)
                {

                    id_Bill = i.ID_Bill; //Lấy cái idBill chưa thanh toán của bàn
                    break;
                }
            }
            if (id_Bill == 0)
            { //Chưa có bill => Tạo bill mới
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                Bill bill = new Bill();
                bill.ID_Account = 1; // SỬA LẠI CHỖ NÀY !!!!!!!!!!!!!!!!!!! ID_Account là id của acc đang đăng nhập
                bill.ID_Table = idTable;
                bill.Pay_Status = false;
                bill.Order_Day = DateTime.Parse(currentDate);
                bill.Order_Time = TimeSpan.Parse(currentTime);
                bill.Price = 0;
                bill.Flag = true;
                db.Bills.Add(bill);
                db.SaveChanges();
            }
            foreach (Bill i in Return_Bill())
            {
                if (i.Pay_Status == false && i.ID_Table == idTable)
                {

                    id_Bill = i.ID_Bill; //Lấy cái idBill chưa thanh toán của bàn
                    break;
                }
            }
            Bill_Detail bill_Detail = new Bill_Detail();
            bill_Detail.ID_Bill = id_Bill;
            bill_Detail.ID_Product = Return_ProductId(foodName);
            bill_Detail.Quantity = Quantity;
            bill_Detail.Flag = true;
            db.Bill_Detail.Add(bill_Detail);
            db.SaveChanges();
        }

        public void SetTableStatus(int idTable, int status)
        {
            PBL3Entities db = new PBL3Entities();
            Table table = db.Tables.Find(idTable);
            if (status == 1) table.Status = true;
            else table.Status = false;
            db.SaveChanges();
        }

        public void Delete_BillDetails(int idTable, string foodName, int Quantity)
        {
            PBL3Entities db = new PBL3Entities();
            int idFood = Return_ProductId(foodName);
            int id_Bill = 0;
            foreach (Bill i in Return_Bill())
            {
                if (i.Pay_Status == false && i.ID_Table == idTable)
                {//Chưa thanh toán 

                    id_Bill = i.ID_Bill;
                    break;
                }
            }
            var billDetail = db.Bill_Detail.Where(p => p.ID_Product == idFood
                            && p.ID_Bill == id_Bill && p.Flag == true
                            && p.Quantity == Quantity).FirstOrDefault();
            db.Bill_Detail.Remove(billDetail);
            db.SaveChanges();
        }

        public void CheckOut_Bill(int idTable, int Price)
        {
            int idBill = 0;
            foreach (Bill i in Return_Bill())
            {
                if (i.Pay_Status == false && i.ID_Table == idTable)
                {//Chưa thanh toán 
                    idBill = i.ID_Bill;
                    break;
                }
            }
            PBL3Entities db = new PBL3Entities();
            Bill Bill = db.Bills.Where(p => p.ID_Bill == idBill).FirstOrDefault();
            Bill.Pay_Status = true;
            Bill.Price = Price;
            db.SaveChanges();
        }
        public List<ProductDatagridview> GetDGV_Product()
        {
            PBL3Entities db = new PBL3Entities();
            List<ProductDatagridview> result = new List<ProductDatagridview>();
            foreach (Product i in Return_Product())
            {
                result.Add(new ProductDatagridview
                {
                    ID_Product = i.ID_Product,
                    Name = i.Name,
                    Price = (int)i.Price,
                    Category_Name = i.Category.Category_Name,
                });
            }
            return result;
        }
        public void Add_Product(Product product)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        public void Edit_Product(Product product)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                var s = db.Products.Where(p => p.ID_Product == product.ID_Product).FirstOrDefault();
                s = product;
                db.SaveChanges();
            }
        }
        public void Delete_Product(int ID_Product)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                var s = db.Products.Where(p => p.ID_Product == ID_Product).FirstOrDefault();
                db.Products.Remove(s);
                db.SaveChanges();
            }
        }
        public List<ProductDatagridview> GetDGV_Product_Search(string Product_Name)
        {
            PBL3Entities db = new PBL3Entities();
            List<ProductDatagridview> result = new List<ProductDatagridview>();
            foreach (Product i in Return_Product())
            {
                if (i.ID_Product.ToString() == (Product_Name))
                {
                    result.Add(new ProductDatagridview
                    {
                        ID_Product = i.ID_Product,
                        Name = i.Name,
                        Price = (int)i.Price,
                        Category_Name = i.Category.Category_Name
                    });
                }
            }
            return result;
        }

        public bool Add_Table(string Table_Name, bool status, string position)
        {
            PBL3Entities db = new PBL3Entities();
            Table table = new Table
            {
                Table_Name = Table_Name,
                Status = status,
                Position = position,
                Flag = true
            };
            db.Tables.Add(table);
            db.SaveChanges();
            return true;

        }
    }
}
