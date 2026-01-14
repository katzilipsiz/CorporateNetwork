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

        // Указываем точные имена таблиц (как в вашей базе)
        modelBuilder.Entity<MainDepartment>().ToTable("MainDepartment");
        modelBuilder.Entity<Department>().ToTable("Department");
        modelBuilder.Entity<Employee>().ToTable("Employee");
        modelBuilder.Entity<Position>().ToTable("Position");
        modelBuilder.Entity<Candidate>().ToTable("Candidate");
        modelBuilder.Entity<Interview>().ToTable("Interview");
        modelBuilder.Entity<VacationCalendar>().ToTable("VacationCalendar");
        modelBuilder.Entity<DayOffCalendar>().ToTable("DayOffCalendar");
        modelBuilder.Entity<TrainingCalendar>().ToTable("TrainingCalendar");
        modelBuilder.Entity<MaterialType>().ToTable("MaterialType");
        modelBuilder.Entity<Material>().ToTable("Material");
        modelBuilder.Entity<TrainingMaterial>().ToTable("TrainingMaterial");
        modelBuilder.Entity<MaterialAuthor>().ToTable("MaterialAuthor");
        modelBuilder.Entity<EventStatus>().ToTable("EventStatus");
        modelBuilder.Entity<EventType>().ToTable("EventType");
        modelBuilder.Entity<Event>().ToTable("Event");
        modelBuilder.Entity<EventResponsible>().ToTable("EventResponsible");
        modelBuilder.Entity<WorkCalendar>().ToTable("WorkCalendar");
        modelBuilder.Entity<WorkSchedule>().ToTable("WorkSchedule");
        modelBuilder.Entity<DepartmentStructure>().ToTable("DepartmentStructure");

        // Настройка составных ключей
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
    }
}