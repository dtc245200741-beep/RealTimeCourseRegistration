
namespace Registration.API.Models;

public class CourseRegistration
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public int CourseSectionId { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public RegistrationStatus Status { get; set; }
        = RegistrationStatus.Registered;
}
