namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PrinterName = c.String(),
                        BackColor = c.String(),
                        ForeColor = c.String(),
                        FontSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Barcode = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ImageURL = c.String(),
                        BackColor = c.String(),
                        ForeColor = c.String(),
                        FontSize = c.Int(nullable: false),
                        UnitOfMeasure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        TerminalName = c.String(),
                        CreatingUserName = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        LastUpdateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        TicketGuid = c.Guid(nullable: false),
                        TableId = c.Int(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        TicketNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        LastOrderDate = c.DateTime(nullable: false),
                        LastPaymentDate = c.DateTime(nullable: false),
                        IsOpened = c.Boolean(nullable: false),
                        RemainingAmount = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        TerminalName = c.String(),
                        Note = c.String(),
                        LastModifiedUserName = c.String(),
                        CreatedUserName = c.String(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .Index(t => t.TableId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        TenderedAmount = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        TerminalName = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.TableId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        Keyword = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackColor = c.String(),
                        ForeColor = c.String(),
                        FontSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTypeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Tickets", "TableId", "dbo.Tables");
            DropForeignKey("dbo.Tables", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Payments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Orders", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Tables", new[] { "SectionId" });
            DropIndex("dbo.Payments", new[] { "TicketId" });
            DropIndex("dbo.Tickets", new[] { "TableId" });
            DropIndex("dbo.Orders", new[] { "TicketId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Sections");
            DropTable("dbo.Tables");
            DropTable("dbo.Payments");
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
