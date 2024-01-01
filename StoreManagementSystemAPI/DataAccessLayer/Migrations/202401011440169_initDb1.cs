namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "User_Id", "dbo.Users");
            DropIndex("dbo.OrderDetails", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        PaymentBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.OrderDetails", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.OrderDetails", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.OrderDetails", "CustomerId", "dbo.Customers", "Id");
            DropColumn("dbo.OrderDetails", "User_Id");
            DropColumn("dbo.Orders", "OrderType");
            DropColumn("dbo.Orders", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "User_Id", c => c.Int());
            AddColumn("dbo.Orders", "OrderType", c => c.String());
            AddColumn("dbo.OrderDetails", "User_Id", c => c.Int());
            DropForeignKey("dbo.ProductOrders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.CustomerOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ProductOrders", new[] { "ProductID" });
            DropIndex("dbo.ProductOrders", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.CustomerOrders", new[] { "CustomerID" });
            DropIndex("dbo.CustomerOrders", new[] { "OrderID" });
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.OrderDetails", "CustomerId");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.CustomerOrders");
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.OrderDetails", "User_Id");
            AddForeignKey("dbo.OrderDetails", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
        }
    }
}
