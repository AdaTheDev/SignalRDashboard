(function (signalrdashboardCore) {
    signalrdashboardCore.ConnectedUsersComponent =
      ng.core.Component({
          selector: 'connected-users',
          templateUrl: '/scripts/app/templates/core/ConnectedUsersComponent.html'
      })
      .Class({
          constructor: function() {
              this.model = new signalrdashboardCore.ConnectedUsers();
              this.componentName = 'ConnectedUsers';
              signalrdashboard.dashboard.registerComponent(this);
          },
          ngOnInit: function() {              
              signalrdashboard.dashboard.completeComponentRegistration();             
          },
          setupHub : function(connection) {
            var hub = connection.connectedUsers;
            var model = this.model;
                  
            // Add a client-side hub method that the server will call
            hub.client.updateConnectedUsers = function(stats) {
                model.updateFromData(stats);
            }
        },
        initialiseData: function(connection) {
            var model = this.model;
            connection.connectedUsers.server.getConnectedUsers().done(function(stats) {                                                
                model.updateFromData(stats);
            });
        }
      });
})(window.signalrdashboard.core || (window.signalrdashboard.core = {}));