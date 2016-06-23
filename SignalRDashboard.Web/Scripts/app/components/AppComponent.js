(function (signalrdashboard) {
    signalrdashboard.AppComponent =
      ng.core.Component({
            selector: "dashboard-app",            
            templateUrl: "/scripts/app/templates/core/DashboardComponent.html",
            directives: [signalrdashboard.core.ConnectedUsersComponent]
          }    
      )
      .Class({
          constructor: function() {              
          }          
      });
})(window.signalrdashboard || (window.signalrdashboard = {}));