namespace GraphQLDemo.API.DTOs
{
    public class StudentDTO : PersonDTO
    {
        public double Gpa { get; set; }
        public IEnumerable<CourseDTO> Courses = Enumerable.Empty<CourseDTO>();
    }
}
