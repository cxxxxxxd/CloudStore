namespace IBAstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CartId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        StatusOrderId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.StatusOrders", t => t.StatusOrderId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CartId)
                .Index(t => t.UserId)
                .Index(t => t.StatusOrderId)
                .Index(t => t.DeliveryId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Housing = c.String(),
                        Flat = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Photo = c.Binary(),
            //            Description = c.String(),
            //            Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ManufacturerId = c.Int(nullable: false),
            //            StatusProductId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
            //    .ForeignKey("dbo.StatusProducts", t => t.StatusProductId, cascadeDelete: true)
            //    .Index(t => t.ManufacturerId)
            //    .Index(t => t.StatusProductId);
            
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Manufacturers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.StatusProducts",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Cart_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            //CreateTable(
            //    "dbo.CategoryProducts",
            //    c => new
            //        {
            //            Category_Id = c.Int(nullable: false),
            //            Product_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Category_Id, t.Product_Id })
            //    .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
            //    .Index(t => t.Category_Id)
            //    .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "StatusProductId", "dbo.StatusProducts");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.CategoryProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "StatusOrderId", "dbo.StatusOrders");
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Orders", "CartId", "dbo.Carts");
            DropIndex("dbo.CategoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.CategoryProducts", new[] { "Category_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "StatusProductId" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropIndex("dbo.Orders", new[] { "DeliveryId" });
            DropIndex("dbo.Orders", new[] { "StatusOrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "CartId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.ProductCarts");
            DropTable("dbo.StatusProducts");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.StatusOrders");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.Carts");
        }
    }
}
