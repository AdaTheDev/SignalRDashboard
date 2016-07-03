using System.Threading.Tasks;
using SignalRDashboard.Data.Core.Hubs.Models;
using SignalRDashboard.Data.Core.Pollers;

namespace SignalRDashboard.Data.Core.Hubs
{
    public abstract class PollingHub<TModel> : DashboardHub where TModel:DashboardHubModel
    {
        private readonly IDatasourcePoller<TModel> _datasourcePoller;

        protected PollingHub(IHubUserConnectionTrackingStrategy connectionTrackingStrategy, IDatasourcePoller<TModel> datasourcePoller) : base(connectionTrackingStrategy)
        {
            _datasourcePoller = datasourcePoller;
        }

        protected TModel Model => _datasourcePoller.Model;

        public override Task OnConnected()
        {
            var task = base.OnConnected();
            _datasourcePoller.UserConnected();
            return task;
        }

        public virtual TModel GetModel()
        {
            return Model;
        }
    }
}