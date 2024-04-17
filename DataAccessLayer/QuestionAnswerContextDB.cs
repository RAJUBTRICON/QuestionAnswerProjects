using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class QuestionAnswerContextDB: DbContext
    {
        public DbSet<Question>? Questions { get; set; } 
        public DbSet<Answer>? Answers { get; set; } 
        public DbSet<Category>? Categories { get; set; }

        public QuestionAnswerContextDB(DbContextOptions<QuestionAnswerContextDB> options) : base(options) { }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Answer>().HasOne(a => a.questions).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId);

           // modelBuilder.Entity<Question>().HasOne(q => q.categories).WithMany(c => c.Questions).HasForeignKey(q => q.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
