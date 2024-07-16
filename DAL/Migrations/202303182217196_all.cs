namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bartars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.choose1",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.managers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        manageName = c.String(),
                        age = c.Int(nullable: false),
                        homManyYears = c.Int(nullable: false),
                        managePhonn = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.players",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        playerName = c.String(),
                        phoneNumber = c.String(),
                        age = c.Int(nullable: false),
                        fatherName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sms");
            DropTable("dbo.players");
            DropTable("dbo.managers");
            DropTable("dbo.logins");
            DropTable("dbo.choose1");
            DropTable("dbo.bartars");
        }
    }
}
