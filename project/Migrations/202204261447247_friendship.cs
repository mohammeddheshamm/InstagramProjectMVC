namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class friendship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        user1id = c.Int(nullable: false),
                        user2id = c.Int(nullable: false),
                        Friend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.user1id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.user2id, cascadeDelete: false)
                .Index(t => t.user1id)
                .Index(t => t.user2id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "user2id", "dbo.Users");
            DropForeignKey("dbo.Friendships", "user1id", "dbo.Users");
            DropIndex("dbo.Friendships", new[] { "user2id" });
            DropIndex("dbo.Friendships", new[] { "user1id" });
            DropTable("dbo.Friendships");
        }
    }
}
