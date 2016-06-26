(function (signalrdashboardDemo) {
    signalrdashboardDemo.SiteStatisticsComponent =
      ng.core.Component({
          selector: 'demo-site-statistics',
          templateUrl: '/scripts/app/templates/demo/SiteStatisticsComponent.html'
      })
      .Class({
          constructor: function() {
              this.model = new signalrdashboardDemo.SiteStatistics();
              this.componentName = 'DemoSiteStatistics';
              signalrdashboard.dashboard.registerComponent(this);
          },
          ngOnInit: function() {              
              signalrdashboard.dashboard.completeComponentRegistration();             
          },
          setupHub : function(connection) {
            var hub = connection.demoSiteStatistics;
            var model = this.model;
            
            // Add a client-side hub method that the server will call
            hub.client.updateDemoSiteStatistics = function(stats) {
                model.updateFromData(stats);
            };
          },
          initialiseData: function(connection) {
              var model = this.model;
             
              connection.demoSiteStatistics.server.getDemoSiteStatistics().done(function(stats) {
                  model.updateFromData(stats);
              });                    
          }
          });
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));