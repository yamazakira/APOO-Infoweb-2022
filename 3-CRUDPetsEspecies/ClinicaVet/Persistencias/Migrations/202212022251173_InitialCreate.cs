namespace Persistencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        ConsultaId = c.Long(nullable: false, identity: true),
                        Sintomas = c.String(),
                        ConsultaData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultaId);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        EspecieId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EspecieId);
            
            CreateTable(
                "dbo.Exames",
                c => new
                    {
                        ExameId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        ConsultaId = c.Long(),
                    })
                .PrimaryKey(t => t.ExameId)
                .ForeignKey("dbo.Consultas", t => t.ConsultaId)
                .Index(t => t.ConsultaId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        EspecieId = c.Long(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Especies", t => t.EspecieId)
                .Index(t => t.EspecieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "EspecieId", "dbo.Especies");
            DropForeignKey("dbo.Exames", "ConsultaId", "dbo.Consultas");
            DropIndex("dbo.Pets", new[] { "EspecieId" });
            DropIndex("dbo.Exames", new[] { "ConsultaId" });
            DropTable("dbo.Pets");
            DropTable("dbo.Exames");
            DropTable("dbo.Especies");
            DropTable("dbo.Consultas");
        }
    }
}
