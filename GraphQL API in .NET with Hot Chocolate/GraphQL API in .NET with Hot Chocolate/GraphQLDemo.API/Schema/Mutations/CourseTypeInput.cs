using GraphQLDemo.API.Enums;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class CourseTypeInput
    {
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
