using GraphQLDemo.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [Subscribe(With = nameof(SubscribeToCourseUpdate))]
        public CourseResult CourseUpdated([EventMessage] CourseResult course) => course;

        private ValueTask<ISourceStream<CourseResult>> SubscribeToCourseUpdate(Guid courseId, ITopicEventReceiver receiver)
        {
            string updateCourseTopic = $"{courseId}_{nameof(CourseUpdated)}";

            return receiver.SubscribeAsync<CourseResult>(updateCourseTopic);
        }
    }
}
