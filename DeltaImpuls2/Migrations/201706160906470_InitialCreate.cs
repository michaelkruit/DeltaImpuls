namespace DeltaImpuls2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        age = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstname = c.String(nullable: false),
                        lastname = c.String(nullable: false),
                        insertion = c.String(),
                        bondsnr = c.Long(nullable: false),
                        cg = c.Boolean(nullable: false),
                        paratt = c.Boolean(nullable: false),
                        dateborn = c.DateTime(nullable: false),
                        gender = c.Boolean(nullable: false),
                        membersince = c.DateTime(nullable: false),
                        adres = c.String(nullable: false),
                        postcode = c.String(nullable: false, maxLength: 7),
                        city = c.String(nullable: false),
                        phonennumber = c.String(maxLength: 12),
                        mobilenumber = c.String(),
                        email = c.String(nullable: false),
                        categorieID = c.Int(nullable: false),
                        locationID = c.Int(nullable: false),
                        ljID = c.Int(),
                        lsID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.categorie", t => t.categorieID, cascadeDelete: true)
                .ForeignKey("dbo.lj", t => t.ljID)
                .ForeignKey("dbo.location", t => t.locationID, cascadeDelete: true)
                .ForeignKey("dbo.ls", t => t.lsID)
                .Index(t => t.categorieID)
                .Index(t => t.locationID)
                .Index(t => t.ljID)
                .Index(t => t.lsID);
            
            CreateTable(
                "dbo.lj",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        license = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        city = c.String(nullable: false),
                        postcode = c.String(nullable: false, maxLength: 7),
                        adres = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        license = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.members", "lsID", "dbo.ls");
            DropForeignKey("dbo.members", "locationID", "dbo.location");
            DropForeignKey("dbo.members", "ljID", "dbo.lj");
            DropForeignKey("dbo.members", "categorieID", "dbo.categorie");
            DropIndex("dbo.members", new[] { "lsID" });
            DropIndex("dbo.members", new[] { "ljID" });
            DropIndex("dbo.members", new[] { "locationID" });
            DropIndex("dbo.members", new[] { "categorieID" });
            DropTable("dbo.ls");
            DropTable("dbo.location");
            DropTable("dbo.lj");
            DropTable("dbo.members");
            DropTable("dbo.categorie");
        }
    }
}
