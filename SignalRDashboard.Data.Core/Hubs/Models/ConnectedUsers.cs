namespace SignalRDashboard.Data.Core.Hubs.Models
{
    public class ConnectedUsers : ModelBase
    {
        private int _connectedUsers;
        public int NumberOfConnectedUsers
        {
            get { return _connectedUsers; }
            set { SetProperty(ref _connectedUsers, value); }
        }
    }
}
