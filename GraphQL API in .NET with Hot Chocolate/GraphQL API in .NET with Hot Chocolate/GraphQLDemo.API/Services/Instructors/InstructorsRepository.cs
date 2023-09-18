using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Instructors
{
    public class InstructorsRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;

        public InstructorsRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<InstructorDTO?> GetById(Guid instructorId)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                return await schoolDbContext.Instructors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == instructorId);
            }
        }

        public async Task<IEnumerable<InstructorDTO?>> GetManyByIds(IReadOnlyList<Guid> instructorsIds)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                return await schoolDbContext.Instructors
                    .Where(instructor => instructorsIds.Contains(instructor.Id)).ToListAsync();
            }
        }
    }
}
