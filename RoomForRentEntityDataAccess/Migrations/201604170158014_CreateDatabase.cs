namespace RoomForRentEntityDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        AvailableFrom = c.DateTime(nullable: false, precision: 0),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BedRoomCount = c.Int(nullable: false),
                        HasFurniture = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commission = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Note = c.String(maxLength: 128, storeType: "nvarchar"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        BuildingId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Number = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Ward = c.String(maxLength: 16, storeType: "nvarchar"),
                        District = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        Province = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 16, unicode: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartments", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Telephones", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Emails", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Apartments", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Telephones", new[] { "OwnerId" });
            DropIndex("dbo.Emails", new[] { "OwnerId" });
            DropIndex("dbo.Apartments", new[] { "OwnerId" });
            DropIndex("dbo.Apartments", new[] { "BuildingId" });
            DropTable("dbo.Telephones");
            DropTable("dbo.Emails");
            DropTable("dbo.Owners");
            DropTable("dbo.Buildings");
            DropTable("dbo.Apartments");
        }
    }
}
