using BdHelper.Classes;
using Microsoft.EntityFrameworkCore;

namespace BdHelper.DbContext;

public class AssistantContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<TrainingExercise> TrainingExercises {get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=AssistentTima.db");
    }
}