namespace Dl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Load : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblGood",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group = c.String(),
                        Firm = c.String(),
                        Model = c.String(),
                        TehnicalInfo = c.String(),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Warranty = c.Int(nullable: false),
                        Status = c.String(),
                        DateReception = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblGood");
        }
    }
}
