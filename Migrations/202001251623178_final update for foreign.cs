namespace Rezervigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalupdateforforeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "Reservation_Id", c => c.Int());
            AddColumn("dbo.User", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.Room", "Reservation_Id");
            CreateIndex("dbo.User", "Reservation_Id");
            AddForeignKey("dbo.Room", "Reservation_Id", "dbo.Reservation", "Id");
            AddForeignKey("dbo.User", "Reservation_Id", "dbo.Reservation", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Reservation_Id", "dbo.Reservation");
            DropForeignKey("dbo.Room", "Reservation_Id", "dbo.Reservation");
            DropIndex("dbo.User", new[] { "Reservation_Id" });
            DropIndex("dbo.Room", new[] { "Reservation_Id" });
            DropColumn("dbo.User", "Reservation_Id");
            DropColumn("dbo.Room", "Reservation_Id");
        }
    }
}
