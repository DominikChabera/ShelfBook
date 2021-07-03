namespace ShelfBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[Authors] ([FirstName], [SecondName], [Surname], [ViewFullName]) VALUES('John', 'Ronald', 'Tolkien', 'J.R.R. Tolkien')");
            Sql("INSERT INTO[dbo].[Authors] ([FirstName], [SecondName], [Surname], [ViewFullName]) VALUES('Ursula', 'Kroeber', 'Le Guin', 'Ursula K. Le Guin')");
            Sql("INSERT INTO[dbo].[Authors] ([FirstName], [SecondName], [Surname], [ViewFullName]) VALUES('Joanne', '', 'Rowling', 'J.K. Rowling')");
            Sql("INSERT INTO[dbo].[Authors] ([FirstName], [SecondName], [Surname], [ViewFullName]) VALUES('Stephen', 'Edwin', 'King', 'Stephen King')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES('Fantasy')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES('Historia')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES('Sensacja')");
            Sql("INSERT INTO[dbo].[Images] ([Title], [ImagePath]) VALUES('wladca pierscieni', '~/images/wladca-pierscieni-3-czesci.jpg')");
            Sql("INSERT INTO[dbo].[Images] ([Title], [ImagePath]) VALUES('harry potter i ksiaze polkrwi', '~/images/harry-potter-i-ksiaze-polkrwi.jpg')");
            Sql("INSERT INTO[dbo].[Images] ([Title], [ImagePath]) VALUES('ziemiomorze', '~/images/ziemiomorze.jpg')");
            Sql("INSERT INTO[dbo].[Images] ([Title], [ImagePath]) VALUES('pozniej', '~/images/pozniej.jpg')");
            Sql("INSERT INTO[dbo].[Prices] ([NormalPrice], [PromotionalPrice]) VALUES(CAST(89.68 AS Decimal(18, 2)), CAST(69.95 AS Decimal(18, 2)))");
            Sql("INSERT INTO[dbo].[Prices] ([NormalPrice], [PromotionalPrice]) VALUES(CAST(48.88 AS Decimal(18, 2)), CAST(45.95 AS Decimal(18, 2)))");
            Sql("INSERT INTO[dbo].[Prices] ([NormalPrice], [PromotionalPrice]) VALUES(CAST(69.73 AS Decimal(18, 2)), CAST(48.11 AS Decimal(18, 2)))");
            Sql("INSERT INTO[dbo].[Prices] ([NormalPrice], [PromotionalPrice]) VALUES(CAST(47.79 AS Decimal(18, 2)), CAST(45.87 AS Decimal(18, 2)))");
            Sql("INSERT INTO[dbo].[PublishingHouses] ([Name]) VALUES('Muza')");
            Sql("INSERT INTO[dbo].[PublishingHouses] ([Name]) VALUES('Media Rodzina')");
            Sql("INSERT INTO[dbo].[PublishingHouses] ([Name]) VALUES('Albatros')");
            Sql("INSERT INTO[dbo].[PublishingHouses] ([Name]) VALUES('Proszynski i S-ka')");

        }
        
        public override void Down()
        {
        }
    }
}
