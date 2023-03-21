namespace baitapltw.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProduct_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropColumn("dbo.Product", "ProductCateId");
            RenameColumn(table: "dbo.Product", name: "Category_Id", newName: "ProductCateId");
            AddColumn("dbo.Product", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductCateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductCateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductCateId");
            AddForeignKey("dbo.Product", "ProductCateId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCateId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "ProductCateId" });
            AlterColumn("dbo.Product", "ProductCateId", c => c.Int());
            AlterColumn("dbo.Product", "ProductCateId", c => c.Int());
            DropColumn("dbo.Product", "Year");
            RenameColumn(table: "dbo.Product", name: "ProductCateId", newName: "Category_Id");
            AddColumn("dbo.Product", "ProductCateId", c => c.Int());
            CreateIndex("dbo.Product", "Category_Id");
            AddForeignKey("dbo.Product", "Category_Id", "dbo.Category", "Id");
        }
    }
}
