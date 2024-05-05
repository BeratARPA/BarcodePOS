using Database.Models;
using System;
using System.Collections.Generic;

namespace Database.Data
{
    public class DataSeeder
    {
        public static void Seed()
        {
            SQLContext _context = new SQLContext();

            GenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(_context);
            GenericRepository<CompanyInformation> _genericRepositoryCompanyInformation = new GenericRepository<CompanyInformation>(_context);
            GenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(_context);
            GenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(_context);
            GenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(_context);
            GenericRepository<Role> _genericRepositoryRole = new GenericRepository<Role>(_context);
            GenericRepository<Section> _genericRepositorySection = new GenericRepository<Section>(_context);
            GenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>(_context);
            GenericRepository<User> _genericRepositoryUser = new GenericRepository<User>(_context);

            #region Role&User
            var roleExist = _genericRepositoryRole.Get(x => x.Name == "Admin");
            if (roleExist == null)
            {
                Role role = new Role
                {
                    Name = "Admin"
                };

                role = _genericRepositoryRole.Add(role);

                var managerExist = _genericRepositoryUser.Get(x => x.Name == "Manager");
                if (managerExist == null)
                {
                    User user = new User
                    {
                        RoleId = role.RoleId,
                        Name = "Manager",
                        Surname = "",
                        Password = "1"
                    };

                    _genericRepositoryUser.Add(user);
                }
                var employeeExist = _genericRepositoryUser.Get(x => x.Name == "Employee");
                if (employeeExist == null)
                {
                    User user = new User
                    {
                        RoleId = role.RoleId,
                        Name = "Employee",
                        Surname = "",
                        Password = "2"
                    };

                    _genericRepositoryUser.Add(user);
                }
            }
            #endregion

            #region CompanyInformation
            var companyInformationExist = _genericRepositoryCompanyInformation.Get(x => x.Name == "Innovative Software Company");
            if (companyInformationExist == null)
            {
                CompanyInformation companyInformation = new CompanyInformation
                {
                    Name = "Innovative Software Company",
                    Address = "Pursaklar/Ankara",
                    Phone = "05076788918",
                    EMail = "beratarpa@hotmail.com"
                };

                _genericRepositoryCompanyInformation.Add(companyInformation);
            }
            #endregion

            #region Categories&Products
            var categoryExistSalatalar = _genericRepositoryCategory.Get(x => x.Name == "Salatalar");
            var categoryExistCorbalar = _genericRepositoryCategory.Get(x => x.Name == "Çorbalar");
            var categoryExistManav = _genericRepositoryCategory.Get(x => x.Name == "Manav");
            if (categoryExistSalatalar == null && categoryExistCorbalar == null && categoryExistManav == null)
            {
                List<Category> categories = new List<Category>
                {
                    new Category{ Name = "Salatalar",PrinterName = "PDF24",BackColor = "52,58,64",ForeColor = "224,224,224" },
                    new Category{ Name = "Çorbalar",PrinterName = "PDF24",BackColor = "52,58,64",ForeColor = "224,224,224" },
                    new Category{ Name = "Manav",PrinterName = "PDF24",BackColor = "52,58,64",ForeColor = "224,224,224" }
                };

                categories = _genericRepositoryCategory.AddAll(categories);

                var productExistCoban = _genericRepositoryProduct.Get(x => x.Name == "Çoban");
                var productExistSezar = _genericRepositoryProduct.Get(x => x.Name == "Sezar");
                var productExistMercimek = _genericRepositoryProduct.Get(x => x.Name == "Mercimek");
                var productExistEzogelin = _genericRepositoryProduct.Get(x => x.Name == "Ezogelin");
                var productExistDomates = _genericRepositoryProduct.Get(x => x.Name == "Domates");
                if (productExistCoban == null && productExistSezar == null && productExistMercimek == null && productExistEzogelin == null && productExistDomates == null)
                {
                    List<Product> products = new List<Product>
                    {
                        new Product{ CategoryId = categories[0].CategoryId,Index = 0,Barcode = "",Name = "Çoban",Price = 35.5,ImageURL = "",BackColor = "52,58,64",ForeColor = "224,224,224",UnitOfMeasure = 1 },
                        new Product{ CategoryId = categories[0].CategoryId,Index = 0,Barcode = "",Name = "Sezar",Price = 25,ImageURL = "",BackColor = "52,58,64",ForeColor = "224,224,224",UnitOfMeasure = 1 },
                        new Product{ CategoryId = categories[1].CategoryId,Index = 0,Barcode = "",Name = "Mercimek",Price = 54,ImageURL = "",BackColor = "52,58,64",ForeColor = "224,224,224",UnitOfMeasure = 1 },
                        new Product{ CategoryId = categories[1].CategoryId,Index = 0,Barcode = "",Name = "Ezogelin",Price = 42,ImageURL = "",BackColor = "52,58,64",ForeColor = "224,224,224",UnitOfMeasure = 1 },
                        new Product{ CategoryId = categories[2].CategoryId,Index = 0,Barcode = "",Name = "Domates",Price = 20.5,ImageURL = "",BackColor = "52,58,64",ForeColor = "224,224,224",UnitOfMeasure = 0 }
                    };

                    products = _genericRepositoryProduct.AddAll(products);
                }
            };
            #endregion

            #region PaymentType
            var paymentTypeCash = _genericRepositoryPaymentType.Get(x => x.Name == "Cash");
            var paymentTypeVisa = _genericRepositoryPaymentType.Get(x => x.Name == "Visa");
            var paymentTypeGooglePay = _genericRepositoryPaymentType.Get(x => x.Name == "Google Pay");
            if (paymentTypeCash == null & paymentTypeVisa == null & paymentTypeGooglePay == null)
            {
                List<PaymentType> paymentTypes = new List<PaymentType>
                {
                    new PaymentType{ Name = "Cash",BackColor = "52,58,64",ForeColor = "224,224,224" },
                    new PaymentType{ Name = "Visa",BackColor = "52,58,64",ForeColor = "224,224,224" },
                    new PaymentType{ Name = "Google Pay",BackColor = "52,58,64",ForeColor = "224,224,224" }
                };

                _genericRepositoryPaymentType.AddAll(paymentTypes);
            }
            #endregion

            #region Sections&Tables
            var sectionExistSalon = _genericRepositorySection.Get(x => x.Title == "Salon");
            if (sectionExistSalon == null)
            {
                Section section = new Section
                {
                    Keyword = "A",
                    Title = "Salon"
                };

                section = _genericRepositorySection.Add(section);

                for (int i = 1; i <= 10; i++)
                {
                    Table table = new Table
                    {
                        SectionId = section.SectionId,
                        Name = section.Keyword + i,
                        Title = ""
                    };

                    _genericRepositoryTable.Add(table);
                }
            }
            #endregion

            #region Customer
            for (int i = 1; i <= 200; i++)
            {
                var customerExist = _genericRepositoryCustomer.Get(x => x.Name == "Test Name" + i);
                if (customerExist == null)
                {
                    Random random = new Random();
                    int areaCode = random.Next(100, 1000);
                    int[] operatorCodes = { 50, 53, 54, 55, 56, 57, 58, 59 };
                    int operatorIndex = random.Next(0, operatorCodes.Length);
                    int operatorCode = operatorCodes[operatorIndex];
                    int subscriberNumber = random.Next(1000000, 9999999);
                    string phoneNumber = $"0{operatorCode}{areaCode}{subscriberNumber}";

                    Customer customer = new Customer
                    {
                        Name = "Test Name" + i,
                        PhoneNumber = phoneNumber,
                        Address = "Test Address" + i,
                        Note = "Test Note",
                        CreatedDateTime = DateTime.Now,
                        LastUpdateDateTime = DateTime.Now,
                        IsAccount = false,
                        Balance = 0
                    };

                    _genericRepositoryCustomer.Add(customer);
                }
            }
            #endregion
        }
    }
}