namespace LTPTPMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Demo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Demos");
        }
    }
}
