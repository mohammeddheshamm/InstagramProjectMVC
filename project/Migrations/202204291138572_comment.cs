namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userid = c.Int(nullable: false),
                        imageid = c.Int(nullable: false),
                        comment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.imageid, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid)
                .Index(t => t.imageid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "userid", "dbo.Users");
            DropForeignKey("dbo.Comments", "imageid", "dbo.Images");
            DropIndex("dbo.Comments", new[] { "imageid" });
            DropIndex("dbo.Comments", new[] { "userid" });
            DropTable("dbo.Comments");
        }
    }
}
