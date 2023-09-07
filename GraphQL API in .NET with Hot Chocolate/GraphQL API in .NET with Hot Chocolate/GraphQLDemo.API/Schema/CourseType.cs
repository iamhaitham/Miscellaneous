using GraphQLDemo.API.Enums;

namespace GraphQLDemo.API.Schema
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =  string.Empty;
        public Subject Subject { get; set; }
        [GraphQLNonNullType] public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();

        public string GetDescription()
        {
            return $"{Name}: This is a course.";
        }
    }
}
