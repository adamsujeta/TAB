namespace TABprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Druzyna",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        kraj_id = c.Int(),
                        liga_id = c.Int(),
                        stadion_id = c.Int(),
                        trener_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .ForeignKey("dbo.Liga", t => t.liga_id)
                .ForeignKey("dbo.Stadion", t => t.stadion_id)
                .ForeignKey("dbo.Trener", t => t.trener_id)
                .Index(t => t.kraj_id)
                .Index(t => t.liga_id)
                .Index(t => t.stadion_id)
                .Index(t => t.trener_id);
            
            CreateTable(
                "dbo.Kraj",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Liga",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        kraj_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .Index(t => t.kraj_id);
            
            CreateTable(
                "dbo.Mecze",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        wynikPolowa = c.String(),
                        wynikKoniec = c.String(),
                        druzyna1_id = c.Int(),
                        druzyna2_id = c.Int(),
                        stadion_id = c.Int(),
                        Druzyna_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Druzyna", t => t.druzyna1_id)
                .ForeignKey("dbo.Druzyna", t => t.druzyna2_id)
                .ForeignKey("dbo.Stadion", t => t.stadion_id)
                .ForeignKey("dbo.Druzyna", t => t.Druzyna_id)
                .Index(t => t.druzyna1_id)
                .Index(t => t.druzyna2_id)
                .Index(t => t.stadion_id)
                .Index(t => t.Druzyna_id);
            
            CreateTable(
                "dbo.Sedzia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        ranga = c.String(),
                        kraj_id = c.Int(),
                        Mecze_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .ForeignKey("dbo.Mecze", t => t.Mecze_id)
                .Index(t => t.kraj_id)
                .Index(t => t.Mecze_id);
            
            CreateTable(
                "dbo.Stadion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        adres = c.String(),
                        pojemnosc = c.Int(nullable: false),
                        kraj_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .Index(t => t.kraj_id);
            
            CreateTable(
                "dbo.Trener",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        data_urodzenia = c.DateTime(nullable: false),
                        kraj_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .Index(t => t.kraj_id);
            
            CreateTable(
                "dbo.Zawodnik",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        wzrost = c.Int(nullable: false),
                        waga = c.Int(nullable: false),
                        pozycja = c.String(),
                        numer = c.Int(nullable: false),
                        data_urodzenia = c.DateTime(nullable: false),
                        druzyna_id = c.Int(),
                        kraj_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Druzyna", t => t.druzyna_id)
                .ForeignKey("dbo.Kraj", t => t.kraj_id)
                .Index(t => t.druzyna_id)
                .Index(t => t.kraj_id);
            
            CreateTable(
                "dbo.Kary",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rodzaj = c.String(),
                        opis = c.String(),
                        data = c.DateTime(nullable: false),
                        zawodnik_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Zawodnik", t => t.zawodnik_id)
                .Index(t => t.zawodnik_id);
            
            CreateTable(
                "dbo.Kontuzje",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rodzaj = c.String(),
                        data_od = c.DateTime(nullable: false),
                        data_do = c.DateTime(nullable: false),
                        zawodnik_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Zawodnik", t => t.zawodnik_id)
                .Index(t => t.zawodnik_id);
            
            CreateTable(
                "dbo.Statystyki",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bramki = c.Int(nullable: false),
                        kartkiCzerwone = c.Int(nullable: false),
                        kartkiZolte = c.Int(nullable: false),
                        mecz_id = c.Int(),
                        zawodnik_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mecze", t => t.mecz_id)
                .ForeignKey("dbo.Zawodnik", t => t.zawodnik_id)
                .Index(t => t.mecz_id)
                .Index(t => t.zawodnik_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statystyki", "zawodnik_id", "dbo.Zawodnik");
            DropForeignKey("dbo.Statystyki", "mecz_id", "dbo.Mecze");
            DropForeignKey("dbo.Zawodnik", "kraj_id", "dbo.Kraj");
            DropForeignKey("dbo.Kontuzje", "zawodnik_id", "dbo.Zawodnik");
            DropForeignKey("dbo.Kary", "zawodnik_id", "dbo.Zawodnik");
            DropForeignKey("dbo.Zawodnik", "druzyna_id", "dbo.Druzyna");
            DropForeignKey("dbo.Druzyna", "trener_id", "dbo.Trener");
            DropForeignKey("dbo.Trener", "kraj_id", "dbo.Kraj");
            DropForeignKey("dbo.Mecze", "Druzyna_id", "dbo.Druzyna");
            DropForeignKey("dbo.Mecze", "stadion_id", "dbo.Stadion");
            DropForeignKey("dbo.Stadion", "kraj_id", "dbo.Kraj");
            DropForeignKey("dbo.Druzyna", "stadion_id", "dbo.Stadion");
            DropForeignKey("dbo.Sedzia", "Mecze_id", "dbo.Mecze");
            DropForeignKey("dbo.Sedzia", "kraj_id", "dbo.Kraj");
            DropForeignKey("dbo.Mecze", "druzyna2_id", "dbo.Druzyna");
            DropForeignKey("dbo.Mecze", "druzyna1_id", "dbo.Druzyna");
            DropForeignKey("dbo.Liga", "kraj_id", "dbo.Kraj");
            DropForeignKey("dbo.Druzyna", "liga_id", "dbo.Liga");
            DropForeignKey("dbo.Druzyna", "kraj_id", "dbo.Kraj");
            DropIndex("dbo.Statystyki", new[] { "zawodnik_id" });
            DropIndex("dbo.Statystyki", new[] { "mecz_id" });
            DropIndex("dbo.Kontuzje", new[] { "zawodnik_id" });
            DropIndex("dbo.Kary", new[] { "zawodnik_id" });
            DropIndex("dbo.Zawodnik", new[] { "kraj_id" });
            DropIndex("dbo.Zawodnik", new[] { "druzyna_id" });
            DropIndex("dbo.Trener", new[] { "kraj_id" });
            DropIndex("dbo.Stadion", new[] { "kraj_id" });
            DropIndex("dbo.Sedzia", new[] { "Mecze_id" });
            DropIndex("dbo.Sedzia", new[] { "kraj_id" });
            DropIndex("dbo.Mecze", new[] { "Druzyna_id" });
            DropIndex("dbo.Mecze", new[] { "stadion_id" });
            DropIndex("dbo.Mecze", new[] { "druzyna2_id" });
            DropIndex("dbo.Mecze", new[] { "druzyna1_id" });
            DropIndex("dbo.Liga", new[] { "kraj_id" });
            DropIndex("dbo.Druzyna", new[] { "trener_id" });
            DropIndex("dbo.Druzyna", new[] { "stadion_id" });
            DropIndex("dbo.Druzyna", new[] { "liga_id" });
            DropIndex("dbo.Druzyna", new[] { "kraj_id" });
            DropTable("dbo.Statystyki");
            DropTable("dbo.Kontuzje");
            DropTable("dbo.Kary");
            DropTable("dbo.Zawodnik");
            DropTable("dbo.Trener");
            DropTable("dbo.Stadion");
            DropTable("dbo.Sedzia");
            DropTable("dbo.Mecze");
            DropTable("dbo.Liga");
            DropTable("dbo.Kraj");
            DropTable("dbo.Druzyna");
        }
    }
}
