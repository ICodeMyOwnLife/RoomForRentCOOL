namespace RoomForRentSqlServerCompactEntity.Migrations
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
                        Code = c.String(nullable: false, maxLength: 16),
                        AvailableFrom = c.DateTime(nullable: false),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BedRoomCount = c.Int(nullable: false),
                        HasFurniture = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commission = c.String(nullable: false, maxLength: 32),
                        Note = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 32),
                        Number = c.String(nullable: false, maxLength: 16),
                        Street = c.String(nullable: false, maxLength: 32),
                        DistrictId = c.Int(),
                        ProvinceId = c.Int(),
                        WardId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .ForeignKey("dbo.Wards", t => t.WardId)
                .Index(t => t.DistrictId)
                .Index(t => t.ProvinceId)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 64),
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
                        Number = c.String(nullable: false, maxLength: 16),
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
            DropForeignKey("dbo.Wards", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Buildings", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Buildings", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Buildings", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Telephones", new[] { "OwnerId" });
            DropIndex("dbo.Emails", new[] { "OwnerId" });
            DropIndex("dbo.Wards", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropIndex("dbo.Buildings", new[] { "WardId" });
            DropIndex("dbo.Buildings", new[] { "ProvinceId" });
            DropIndex("dbo.Buildings", new[] { "DistrictId" });
            DropIndex("dbo.Apartments", new[] { "OwnerId" });
            DropIndex("dbo.Apartments", new[] { "BuildingId" });
            DropTable("dbo.Telephones");
            DropTable("dbo.Emails");
            DropTable("dbo.Owners");
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.Buildings");
            DropTable("dbo.Apartments");
        }
    }
}
