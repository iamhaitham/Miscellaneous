using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Queries;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Services.Instructors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<InstructorsRepository>();
builder.Services.AddScoped<InstructorDataLoader>();

var app = builder.Build();
app.UseWebSockets();
app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    IDbContextFactory<SchoolDbContext> contextFactory = 
        scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();
    using (SchoolDbContext schoolDbContext = contextFactory.CreateDbContext())
    {
        schoolDbContext.Database.Migrate();
    }
}

app.Run();
