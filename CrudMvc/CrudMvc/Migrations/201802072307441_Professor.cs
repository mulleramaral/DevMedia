namespace CrudMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Professor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Professor");
        }
    }
}
