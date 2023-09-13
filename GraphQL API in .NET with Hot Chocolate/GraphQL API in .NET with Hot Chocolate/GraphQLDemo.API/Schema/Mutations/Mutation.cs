using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services.Courses;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly CourseRepository _courseRepository;
        public Mutation(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResult> CreateCourse(
            CourseTypeInput courseTypeInput, 
            [Service] ITopicEventSender sender
            )
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Name = courseTypeInput.Name,
                Subject = courseTypeInput.Subject,
                InstructorId = courseTypeInput.InstructorId
            };

            courseDTO = await _courseRepository.Create(courseDTO);

            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId,
            };

            await sender.SendAsync(nameof(Subscription.CourseCreated), course);

            return course;
        }

        public async Task<CourseResult> UpdateCourse(
            Guid id, 
            CourseTypeInput courseTypeInput, 
            [Service] ITopicEventSender sender
            )
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = id,
                Name = courseTypeInput.Name,
                Subject = courseTypeInput.Subject,
                InstructorId = courseTypeInput.InstructorId
            };

            courseDTO = await _courseRepository.Update(courseDTO);

            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId,
            };

            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await sender.SendAsync(updateCourseTopic, course);

            return course;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            try
            {
                return await _courseRepository.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
