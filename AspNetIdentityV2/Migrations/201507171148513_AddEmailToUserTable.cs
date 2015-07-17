namespace AspNetIdentityV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmailId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmailId");
        }
    }
}
