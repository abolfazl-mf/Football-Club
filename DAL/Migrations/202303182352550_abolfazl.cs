﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abolfazl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.managers", "homManyYears", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.managers", "homManyYears", c => c.Int(nullable: false));
        }
    }
}