(function(signalrdashboardDemo) {
    signalrdashboardDemo.SiteStatus = SiteStatus;

    function SiteStatus() {
        // Properties matching data model received via SignalR
        this.siteName = "";
        this.url = "";
        this.isSiteUp = true;

        // Error tracking properties
        this.hasSiteDownError = false;

        // Error check conditions
        var model = this;
        var errorChecks = [];
        errorChecks.push({ model: model, condition: function() { return !model.isSiteUp; }, targetProperty: 'hasSiteDownError' });

        this.updateFromData = function(data) {            
            signalrdashboard.mapping.map(data, this);
            signalrdashboard.alertHandler.performErrorChecks('DemoSiteStatus', errorChecks);
        };
    }
    
})(window.signalrdashboard.demo || (window.signalrdashboard.demo = {}));