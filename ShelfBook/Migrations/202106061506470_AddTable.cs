namespace ShelfBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Surname = c.String(),
                        ViewFullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        PriceId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        ISBN = c.String(),
                        ReleaseDate = c.DateTime(),
                        PublishingHouseId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.PriceId, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .Index(t => t.PriceId)
                .Index(t => t.ImageId)
                .Index(t => t.AuthorId)
                .Index(t => t.PublishingHouseId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NormalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionalPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.Books", "PriceId", "dbo.Prices");
            DropForeignKey("dbo.Books", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "PublishingHouseId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "ImageId" });
            DropIndex("dbo.Books", new[] { "PriceId" });
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.Prices");
            DropTable("dbo.Images");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
