namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryedit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Icon");
        }
    }
}
