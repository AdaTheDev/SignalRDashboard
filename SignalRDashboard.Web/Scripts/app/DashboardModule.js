(function (signalrdashboard) {
    signalrdashboard.DashboardModule =
      ng.core.NgModule({
          imports: [ng.platformBrowser.BrowserModule],
          declarations: [
                signalrdashboard.DashboardComponent,
                signalrdashboard.core.ConnectedUsersComponent,
                signalrdashboard.core.ControlsComponent,
                signalrdashboard.demo.SiteStatusComponent,
                signalrdashboard.demo.SiteStatisticsComponent,
                signalrdashboard.demo.BuildMetricsCompnent],
          bootstrap: [signalrdashboard.DashboardComponent]
      })
      .Class({
          constructor: function () { }
      });
})(window.signalrdashboard || (window.signalrdashboard = {}));