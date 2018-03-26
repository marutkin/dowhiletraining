namespace DoWhileTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveTrainingAndApparatLinkToType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainings", "ApparatId", "dbo.TrainingApparats");
            DropIndex("dbo.Trainings", new[] { "ApparatId" });
            AddColumn("dbo.TrainingTypes", "IsCardio", c => c.Boolean(nullable: false));
            AddColumn("dbo.TrainingTypes", "ApparatId", c => c.Int(nullable: false));
            CreateIndex("dbo.TrainingTypes", "ApparatId");
            AddForeignKey("dbo.TrainingTypes", "ApparatId", "dbo.TrainingApparats", "Id", cascadeDelete: true);
            DropColumn("dbo.TrainingApparats", "IsCardio");
            DropColumn("dbo.Trainings", "Name");
            DropColumn("dbo.Trainings", "ApparatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainings", "ApparatId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainings", "Name", c => c.String());
            AddColumn("dbo.TrainingApparats", "IsCardio", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TrainingTypes", "ApparatId", "dbo.TrainingApparats");
            DropIndex("dbo.TrainingTypes", new[] { "ApparatId" });
            DropColumn("dbo.TrainingTypes", "ApparatId");
            DropColumn("dbo.TrainingTypes", "IsCardio");
            CreateIndex("dbo.Trainings", "ApparatId");
            AddForeignKey("dbo.Trainings", "ApparatId", "dbo.TrainingApparats", "Id", cascadeDelete: true);
        }
    }
}
