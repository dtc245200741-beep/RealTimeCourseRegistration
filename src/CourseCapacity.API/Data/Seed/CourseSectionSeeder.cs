
using CourseCapacity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCapacity.API.Data.Seed;

public static class CourseSectionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Nếu đã có dữ liệu thì không thêm lại
        if (await context.CourseSections.AnyAsync())
        {
            return;
        }

        var courses = new List<CourseSection>
        {
            new()
            {
                CourseCode = "IT001",
                CourseName = "Lập trình C#",
                SectionCode = "IT001.01",
                Capacity = 60,
                RegisteredCount = 45
            },
            new()
            {
                CourseCode = "IT002",
                CourseName = "Cơ sở dữ liệu",
                SectionCode = "IT002.01",
                Capacity = 50,
                RegisteredCount = 30
            },
            new()
            {
                CourseCode = "IT003",
                CourseName = "Lập trình Web",
                SectionCode = "IT003.01",
                Capacity = 40,
                RegisteredCount = 40
            }
        };

        await context.CourseSections.AddRangeAsync(courses);
        await context.SaveChangesAsync();
    }
}
