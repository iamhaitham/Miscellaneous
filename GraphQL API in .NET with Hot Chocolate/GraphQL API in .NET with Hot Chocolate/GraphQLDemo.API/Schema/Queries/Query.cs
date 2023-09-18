using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Services.Courses;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        private readonly CourseRepository _courseRepository;

        public Query(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            IEnumerable<CourseDTO> courseDTOs = await _courseRepository.GetAll();

            return courseDTOs.Select(course => new CourseType()
            {
                Id = course.Id,
                Name = course.Name,
                Subject = course.Subject,
                InstructorId = course.InstructorId
            });
        }

        public async Task<CourseType?> GetCourseByIdAsync(Guid id)
        {
            CourseDTO? courseDTO = await _courseRepository.GetById(id);

            if (courseDTO is null)
                return null;

            return new CourseType()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId
            };
        }

        [GraphQLDeprecated("This query is deprecated.")]
        public string Instructions => "Smash that like button and subscribe to SingletonSean";
    }
}
