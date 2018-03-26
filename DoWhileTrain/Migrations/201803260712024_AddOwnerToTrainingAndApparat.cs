namespace DoWhileTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerToTrainingAndApparat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingApparats", "OwnerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Trainings", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TrainingApparats", "OwnerId");
            CreateIndex("dbo.Trainings", "OwnerId");
            AddForeignKey("dbo.TrainingApparats", "OwnerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Trainings", "OwnerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainingApparats", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Trainings", new[] { "OwnerId" });
            DropIndex("dbo.TrainingApparats", new[] { "OwnerId" });
            DropColumn("dbo.Trainings", "OwnerId");
            DropColumn("dbo.TrainingApparats", "OwnerId");
        }
    }
}
