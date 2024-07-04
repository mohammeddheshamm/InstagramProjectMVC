namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Image", c => c.String(nullable: false));
        }
    }
}
