namespace Rezervigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelswithvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
        }
    }
}
