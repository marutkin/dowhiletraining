namespace DoWhileTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingApparats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsCardio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WorkCount = c.Int(nullable: false),
                        WorkoutDate = c.DateTime(nullable: false),
                        TypeId = c.Int(nullable: false),
                        ApparatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingApparats", t => t.ApparatId, cascadeDelete: true)
                .ForeignKey("dbo.TrainingTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.ApparatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "TypeId", "dbo.TrainingTypes");
            DropForeignKey("dbo.Trainings", "ApparatId", "dbo.TrainingApparats");
            DropIndex("dbo.Trainings", new[] { "ApparatId" });
            DropIndex("dbo.Trainings", new[] { "TypeId" });
            DropTable("dbo.Trainings");
            DropTable("dbo.TrainingApparats");
        }
    }
}
