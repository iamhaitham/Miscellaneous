using Bogus;
using GraphQLDemo.API.Enums;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker =
                new Faker<InstructorType>()
                    .RuleFor(i => i.Id, () => Guid.NewGuid())
                    .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                    .RuleFor(i => i.LastName, f => f.Name.LastName())
                    .RuleFor(i => i.Salary, f => f.Random.Double(0, 100000));

            _studentFaker =
                new Faker<StudentType>()
                    .RuleFor(s => s.Id, () => Guid.NewGuid())
                    .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                    .RuleFor(i => i.LastName, f => f.Name.LastName())
                    .RuleFor(s => s.Gpa, f => f.Random.Double(1, 4));

            _courseFaker =
                new Faker<CourseType>()
                    .RuleFor(c => c.Id, () => Guid.NewGuid())
                    .RuleFor(c => c.Name, f => f.Name.JobTitle())
                    .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                    .RuleFor(c => c.Instructor, _instructorFaker.Generate())
                    .RuleFor(c => c.Students, _studentFaker.Generate(3));

        }

        public IEnumerable<CourseType> GetCourses()
        {
            return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);

            CourseType course = _courseFaker.Generate();
            course.Id = id;

            return course;
        }

        [GraphQLDeprecated("This query is deprecated.")]
        public string Instructions => "Smash that like button and subscribe to SingletonSean";
    }
}
