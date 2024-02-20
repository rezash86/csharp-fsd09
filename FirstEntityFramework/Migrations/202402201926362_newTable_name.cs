namespace FirstEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTable_name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Homes", newName: "Home_table");
            AlterColumn("dbo.Home_table", "Address", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Home_table", "Address", c => c.String());
            RenameTable(name: "dbo.Home_table", newName: "Homes");
        }
    }
}
