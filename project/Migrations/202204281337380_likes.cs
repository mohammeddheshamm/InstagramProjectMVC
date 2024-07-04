namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userid = c.Int(nullable: false),
                        imageid = c.Int(nullable: false),
                        Like = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.imageid, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid)
                .Index(t => t.imageid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "userid", "dbo.Users");
            DropForeignKey("dbo.Likes", "imageid", "dbo.Images");
            DropIndex("dbo.Likes", new[] { "imageid" });
            DropIndex("dbo.Likes", new[] { "userid" });
            DropTable("dbo.Likes");
        }
    }
}
