namespace GraphQLDemo.API.DTOs
{
    public class InstructorDTO : PersonDTO
    {
        public double Salary { get; set; }
        public IEnumerable<CourseDTO> Courses = Enumerable.Empty<CourseDTO>();
    }
}
