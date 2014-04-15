namespace KidChores2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KidRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KidId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kids", t => t.KidId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.KidId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Kids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KidRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.KidRooms", "KidId", "dbo.Kids");
            DropIndex("dbo.KidRooms", new[] { "RoomId" });
            DropIndex("dbo.KidRooms", new[] { "KidId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Kids");
            DropTable("dbo.KidRooms");
        }
    }
}
