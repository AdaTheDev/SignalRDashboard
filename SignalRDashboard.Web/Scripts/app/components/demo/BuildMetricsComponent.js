(function (signalrdashboardDemo) {
    signalrdashboardDemo.BuildMetricsCompnent =
      ng.core.Component({
          selector: 'demo-build-metrics',
          templateUrl: '/scripts/app/templates/demo/BuildMetricsComponent.html'
      })
      .Class({
          constructor: function() {
              this.model = new signalrdashboardDemo.BuildMetrics();
              this.componentName = 'DemoBuildMetrics';
              signalrdashboard.dashboard.registerComponent(this);
          },
          ngOnInit: function() {              
              signalrdashboard.dashboard.completeComponentRegistration();             
          },
          setupHub : function(connection) {
            var hub = connection.demoBuildMetrics;
            var model = this.model;
            
            // Add a client-side hub method that the server will call
            hub.client.updateDemoBuildMetrics = function(stats) {
                model.updateFromData(stats);
            };
          },
          initialiseData: function(connection) {
              var model = this.model;
             
              connection.demoBuildMetrics.server.getDemoBuildMetrics().done(function(stats) {
                  model.updateFromData(stats);
              });                    
          }
          });
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));