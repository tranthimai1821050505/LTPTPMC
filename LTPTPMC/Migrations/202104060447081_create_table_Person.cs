namespace LTPTPMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        CCCD = c.String(nullable: false, maxLength: 128, unicode: false),
                        FullName = c.String(unicode: false),
                        Address = c.String(),
                        University = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CCCD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persons");
        }
    }
}
