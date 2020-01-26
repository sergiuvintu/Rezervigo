namespace Rezervigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "Room_Id", "dbo.Room");
            DropIndex("dbo.Reservation", new[] { "Room_Id" });
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservation", "Room_Id");
            AddForeignKey("dbo.Reservation", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "Room_Id", "dbo.Room");
            DropIndex("dbo.Reservation", new[] { "Room_Id" });
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int());
            CreateIndex("dbo.Reservation", "Room_Id");
            AddForeignKey("dbo.Reservation", "Room_Id", "dbo.Room", "Id");
        }
    }
}
