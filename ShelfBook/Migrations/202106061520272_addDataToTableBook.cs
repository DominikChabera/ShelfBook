namespace ShelfBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToTableBook : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[Books] ([Title], [PriceId], [AuthorId], [ISBN], [ReleaseDate], [PublishingHouseId], [ImageId], [GenreId]) VALUES('Wladca Pierscieni 3 czesci', 13, 13, '9788328700789', '2012-10-10 00:00:00', 5, 13, 10)");
            Sql("INSERT INTO[dbo].[Books] ([Title], [PriceId], [AuthorId], [ISBN], [ReleaseDate], [PublishingHouseId], [ImageId], [GenreId]) VALUES('Ziemiomorze', 15, 14, '978-83-7839-665-9', '2013-11-07 00:00:00', 8, 15, 10)");
            Sql("INSERT INTO[dbo].[Books] ([Title], [PriceId], [AuthorId], [ISBN], [ReleaseDate], [PublishingHouseId], [ImageId], [GenreId]) VALUES('Pózniej', 16, 16, '978-83-8215-363-7', '2021-03-10 00:00:00', 7, 16, 12)");
        }
        
        public override void Down()
        {
        }
    }
}
