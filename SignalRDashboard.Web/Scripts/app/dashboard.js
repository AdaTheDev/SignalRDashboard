(function (signalrdashboard) {    
    var _components = [];
    // Make sure this matches the number of components on the dashboard
    var _numberOfComponents = 0;
    
    function initialiseComponents () {            
        // All components' have to set up their callback methods for their corresponding SignalR hubs
        // BEFORE the signalr connection is started.
        for (var i = 0; i < _components.length; i++) {
            _components[i].setupHub($.connection);
        }
        
        $.connection.hub.start().done(function() {
            for (var i = 0; i < _components.length; i++) {
                _components[i].initialiseData($.connection);
            }
        });
    }

    signalrdashboard.dashboard = {                       
        registerComponent : function(component) {                        
            _components.push(component);
        },
        completeComponentRegistration : function() {
            _numberOfComponents++;
            if (_components.length === _numberOfComponents) {
                initialiseComponents();
            }
        }
    };   

    document.addEventListener("DOMContentLoaded", function() {                             
        ng.platform.browser.bootstrap(signalrdashboard.AppComponent);        
    }); 
})(window.signalrdashboard || (window.signalrdashboard = {}));