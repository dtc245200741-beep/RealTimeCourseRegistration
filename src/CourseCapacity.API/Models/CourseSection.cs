
namespace CourseCapacity.API.Models;

public class CourseSection
{
    public int Id { get; set; }

    // Mã học phần
    public string CourseCode { get; set; } = string.Empty;

    // Tên học phần
    public string CourseName { get; set; } = string.Empty;

    // Mã lớp học phần
    public string SectionCode { get; set; } = string.Empty;

    // Sức chứa tối đa
    public int Capacity { get; set; }

    // Số sinh viên đã đăng ký
    public int RegisteredCount { get; set; }

    // Số chỗ còn lại
    public int RemainingSeats => Capacity - RegisteredCount;
}
