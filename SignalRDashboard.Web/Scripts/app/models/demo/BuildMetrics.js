(function(signalrdashboardDemo) {
    signalrdashboardDemo.BuildMetrics = BuildMetrics;

    function BuildMetrics() {
        // Properties matching data model received via SignalR
        this.lastBuildTime = "";
        this.lastBuildDuration = "";
        this.lastBuildSucceeded = true;
        this.totalTestCount = 0;
        this.failedTestCount = 0;
        this.passedTestCount = 0;
        this.lastCommitBy = "";
        this.codeCoverage = 0;

        // Error tracking properties
        this.hasBuildError = false;

        // Error check conditions
        var model = this;
        var errorChecks = [];
        errorChecks.push({ model: model, condition: function() { return !model.lastBuildSucceeded; }, targetProperty: 'hasBuildError' });

        this.updateFromData = function(data) {            
            signalrdashboard.mapping.map(data, this);
            signalrdashboard.alertHandler.performErrorChecks('DemoBuildMetrics', errorChecks);
        };
    }
    
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));