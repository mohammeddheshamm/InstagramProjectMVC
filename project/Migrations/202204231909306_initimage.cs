namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        image = c.String(),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "userid", "dbo.Users");
            DropIndex("dbo.Images", new[] { "userid" });
            DropTable("dbo.Images");
        }
    }
}
