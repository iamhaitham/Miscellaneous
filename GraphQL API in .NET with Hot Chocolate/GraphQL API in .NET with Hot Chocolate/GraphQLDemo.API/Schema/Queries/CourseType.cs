using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Enums;
using GraphQLDemo.API.Services.Instructors;

namespace GraphQLDemo.API.Schema
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();
        public Guid InstructorId { get; set; }

        [GraphQLNonNullType]
        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            InstructorDTO? instructorDTO = await instructorDataLoader.LoadAsync(InstructorId, CancellationToken.None);

            if (instructorDTO is null)
                throw new GraphQLException("The provided instructor id is invalid");

            return new InstructorType()
            {
                Id = instructorDTO.Id,
                FirstName = instructorDTO.FirstName,
                LastName = instructorDTO.LastName,
                Salary= instructorDTO.Salary
            };
        }

        public string GetDescription()
        {
            return $"{Name}: This is a course.";
        }
    }
}
