(function (signalrdashboardDemo) {
    function updateModelArray(currentModelArray, newModelArray) {
        for (var i = 0; i < newModelArray.length; i++) {
            var foundSite = currentModelArray.find(function(site) { return site.url === newModelArray[i].url; });
            if (!foundSite) {
                foundSite = new signalrdashboardDemo.SiteStatus();
                currentModelArray.push(foundSite);
            } 
            foundSite.updateFromData(newModelArray[i]);    
        }
    };

    signalrdashboardDemo.SiteStatusComponent =
      ng.core.Component({
          selector: 'demo-site-status',
          templateUrl: '/scripts/app/templates/demo/SiteStatusComponent.html'
      })
      .Class({
          constructor: function() {
              this.model = [];
              this.componentName = 'DemoSiteStatus';
              signalrdashboard.dashboard.registerComponent(this);
          },
          ngOnInit: function() {              
              signalrdashboard.dashboard.completeComponentRegistration();             
          },
          setupHub : function(connection) {
            var hub = connection.demoSiteStatus;
            var model = this.model;
            
            // Add a client-side hub method that the server will call
            hub.client.updateDemoSiteStatus = function(stats) {
                updateModelArray(model, stats);
            };
          },
          initialiseData: function(connection) {
              var model = this.model;
             
              connection.demoSiteStatus.server.getDemoSiteStatus().done(function(stats) {
                  updateModelArray(model, stats);
              });                    
          }
          });
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));