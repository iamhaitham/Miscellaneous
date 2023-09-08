using GraphQLDemo.API.Enums;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;
        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public CourseResult CreateCourse(CourseInputType courseInputType)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId,
            };

            _courses.Add(courseType);

            return courseType;
        }

        public CourseResult UpdateCourse(Guid id, CourseInputType courseInputType)
        {
            CourseResult? courseType = _courses.FirstOrDefault(c => c.Id == id);

            if (courseType == null)
                throw new GraphQLException(new Error ("Course not found.", "COURSE_NOT_FOUND"));

            courseType.Name = courseInputType.Name;
            courseType.Subject = courseInputType.Subject;
            courseType.InstructorId = courseInputType.InstructorId;

            return courseType;
        }

        public bool DeleteCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
