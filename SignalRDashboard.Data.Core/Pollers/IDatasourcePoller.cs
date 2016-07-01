using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Core.Pollers
{
    public interface IDatasourcePoller<out TModel> where TModel:DashboardHubModel
    {
        void UserConnected();

        TModel Model { get; }
    }
}