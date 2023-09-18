using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Courses
{
    public class CourseRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;

        public CourseRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                return await schoolDbContext.Courses
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<CourseDTO?> GetById(Guid courseId)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                return await schoolDbContext.Courses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == courseId);
            }
        }

        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                schoolDbContext.Courses.Add(course);
                await schoolDbContext.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                schoolDbContext.Courses.Update(course);
                await schoolDbContext.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> Delete(Guid courseId)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    Id = courseId
                };

                schoolDbContext.Courses.Remove(course);
                return await schoolDbContext.SaveChangesAsync() > 0;
            }
        }
    }
}
