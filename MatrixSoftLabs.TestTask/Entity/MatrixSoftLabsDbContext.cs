using Microsoft.EntityFrameworkCore;

namespace MatrixSoftLabs.TestTask.Entity;

public class MatrixSoftLabsDbContext : DbContext
{
    public MatrixSoftLabsDbContext(DbContextOptions<MatrixSoftLabsDbContext> options) : base(options)
    {

    }
    public DbSet<AspNetUser> AspNetUsers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<VacancyCategory> VacancyCategories { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(employee => employee.AspNetUser)
            .WithOne(user => user.Employee)
            .HasForeignKey<Employee>(employee => employee.UserId);


        modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.VacancyCategory)
            .WithMany(vc => vc.Vacancies)
            .HasForeignKey(v => v.VacancyCategoryId);

        modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.UserApproved)
            .WithMany(user => user.ApprovedVacancies)
            .HasForeignKey(v => v.UserApprovedId);
    }
}