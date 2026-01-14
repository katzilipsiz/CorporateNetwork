using CorporateNetwork.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<MainDepartment> MainDepartments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<DepartmentStructure> DepartmentStructures { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<VacationCalendar> VacationCalendars { get; set; }
    public DbSet<DayOffCalendar> DayOffCalendars { get; set; }
    public DbSet<TrainingCalendar> TrainingCalendars { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<TrainingMaterial> TrainingMaterials { get; set; }
    public DbSet<MaterialAuthor> MaterialAuthors { get; set; }
    public DbSet<EventStatus> EventStatuses { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventResponsible> EventResponsibles { get; set; }
    public DbSet<WorkCalendar> WorkCalendars { get; set; }
    public DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DepartmentStructure>()
            .HasKey(ds => new { ds.DepartmentCode, ds.PersonalNumber, ds.PositionCode });

        modelBuilder.Entity<Interview>()
            .HasKey(i => new { i.EmployeeID, i.InterviewDateTime });

        modelBuilder.Entity<TrainingMaterial>()
            .HasKey(tm => new { tm.TrainingCode, tm.MaterialCode });

        modelBuilder.Entity<MaterialAuthor>()
            .HasKey(ma => new { ma.MaterialCode, ma.EmployeeID });

        modelBuilder.Entity<EventResponsible>()
            .HasKey(er => new { er.EventCode, er.EmployeeID });

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique()
            .HasFilter("[Email] IS NOT NULL");

        modelBuilder.Entity<WorkCalendar>()
            .HasIndex(wc => wc.CalendarDate)
            .IsUnique();

        modelBuilder.Entity<Event>()
            .ToTable("Event");
    }
}