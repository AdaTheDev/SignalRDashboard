(function(signalrdashboardDemo) {
    signalrdashboardDemo.SiteStatistics = SiteStatistics;

    function SiteStatistics() {
        // Properties matching data model received via SignalR
        this.visitors = 0;
        this.pageViews = 0;
        this.sessions = 0;
        this.averageSessionDuration = "";
        this.pagesPerSession = 0.0;
        this.bounceRate = 0.0;

        this.updateFromData = function(data) {            
            signalrdashboard.mapping.map(data, this);
        };
    }
    
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));