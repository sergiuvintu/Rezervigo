namespace Rezervigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationfinal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "Room_Number", "dbo.Room");
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User");
            DropIndex("dbo.Reservation", new[] { "Room_Number" });
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            RenameColumn(table: "dbo.Reservation", name: "Room_Number", newName: "Room_Id");
            DropPrimaryKey("dbo.Room");
            AddColumn("dbo.Room", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservation", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Room", "Number", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Room", "Id");
            CreateIndex("dbo.Reservation", "Room_Id");
            CreateIndex("dbo.Reservation", "User_Id");
            AddForeignKey("dbo.Reservation", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservation", "User_Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User");
            DropForeignKey("dbo.Reservation", "Room_Id", "dbo.Room");
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            DropIndex("dbo.Reservation", new[] { "Room_Id" });
            DropPrimaryKey("dbo.Room");
            AlterColumn("dbo.Room", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservation", "User_Id", c => c.Int());
            AlterColumn("dbo.Reservation", "Room_Id", c => c.Int());
            DropColumn("dbo.Room", "Id");
            AddPrimaryKey("dbo.Room", "Number");
            RenameColumn(table: "dbo.Reservation", name: "Room_Id", newName: "Room_Number");
            CreateIndex("dbo.Reservation", "User_Id");
            CreateIndex("dbo.Reservation", "Room_Number");
            AddForeignKey("dbo.Reservation", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Reservation", "Room_Number", "dbo.Room", "Number");
        }
    }
}
