namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
