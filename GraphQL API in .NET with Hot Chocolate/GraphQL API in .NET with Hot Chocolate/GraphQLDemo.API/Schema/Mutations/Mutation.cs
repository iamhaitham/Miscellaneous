using GraphQLDemo.API.Enums;
using GraphQLDemo.API.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;
        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public async Task<CourseResult> CreateCourse(
            CourseInputType courseInputType, 
            [Service] ITopicEventSender sender
            )
        {
            CourseResult course = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId,
            };

            _courses.Add(course);

            await sender.SendAsync(nameof(Subscription.CourseCreated), course);

            return course;
        }

        public async Task<CourseResult> UpdateCourse(
            Guid id, 
            CourseInputType courseInputType, 
            [Service] ITopicEventSender sender
            )
        {
            CourseResult? course = _courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new GraphQLException(new Error ("Course not found.", "COURSE_NOT_FOUND"));

            course.Name = courseInputType.Name;
            course.Subject = courseInputType.Subject;
            course.InstructorId = courseInputType.InstructorId;

            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await sender.SendAsync(updateCourseTopic, course);

            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
