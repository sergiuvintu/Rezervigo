namespace Rezervigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User");
            DropIndex("dbo.Reservation", new[] { "Room_Id" });
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int());
            AlterColumn("dbo.Reservation", "User_Id", c => c.Int());
            CreateIndex("dbo.Reservation", "Room_Id");
            CreateIndex("dbo.Reservation", "User_Id");
            AddForeignKey("dbo.Reservation", "Room_Id", "dbo.Room", "Id");
            AddForeignKey("dbo.Reservation", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User");
            DropForeignKey("dbo.Reservation", "Room_Id", "dbo.Room");
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            DropIndex("dbo.Reservation", new[] { "Room_Id" });
            AlterColumn("dbo.Reservation", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservation", "User_Id");
            CreateIndex("dbo.Reservation", "Room_Id");
            AddForeignKey("dbo.Reservation", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservation", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
        }
    }
}
