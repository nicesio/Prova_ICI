namespace ProvaCandidato.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provacandidato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.ClienteObservacaos",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 255),
                        codigo_cliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cliente", t => t.codigo_cliente, cascadeDelete: true)
                .Index(t => t.codigo_cliente);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        data_nascimento = c.DateTime(),
                        codigo_cidade = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cidade", t => t.codigo_cidade, cascadeDelete: true)
                .Index(t => t.codigo_cidade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteObservacaos", "codigo_cliente", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "codigo_cidade", "dbo.Cidade");
            DropIndex("dbo.Cliente", new[] { "codigo_cidade" });
            DropIndex("dbo.ClienteObservacaos", new[] { "codigo_cliente" });
            DropTable("dbo.Cliente");
            DropTable("dbo.ClienteObservacaos");
            DropTable("dbo.Cidade");
        }
    }
}
