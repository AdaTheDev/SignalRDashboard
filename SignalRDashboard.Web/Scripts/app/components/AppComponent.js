﻿(function (signalrdashboard) {
    signalrdashboard.AppComponent =
      ng.core.Component({
            selector: "dashboard-app",            
            templateUrl: "/scripts/app/templates/core/DashboardComponent.html",
            directives: [signalrdashboard.core.ConnectedUsersComponent,
                signalrdashboard.core.ControlsComponent,
                signalrdashboard.demo.SiteStatusComponent,
                signalrdashboard.demo.SiteStatisticsComponent,
                signalrdashboard.demo.BuildMetricsCompnent
            ]
          }    
      )
      .Class({
          constructor: function() {              
          }          
      });
})(window.signalrdashboard || (window.signalrdashboard = {}));