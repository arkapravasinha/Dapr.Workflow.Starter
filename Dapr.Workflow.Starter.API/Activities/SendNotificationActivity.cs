using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DTO;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class SendNotificationActivity : WorkflowActivity<NotificationSentWorkflowRequest, bool>
    {
        private readonly ApplicationDBContext applicationDBContext;

        public SendNotificationActivity(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public override Task<bool> RunAsync(WorkflowActivityContext context, NotificationSentWorkflowRequest input)
        {
            return Task.FromResult<bool>(true);
        }
    }
}
