
using CourseCapacity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCapacity.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CourseSection> CourseSections => Set<CourseSection>();
}

