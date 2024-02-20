namespace FirstEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Home_table", "Address", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Home_table", "Address", c => c.String(maxLength: 10));
        }
    }
}
