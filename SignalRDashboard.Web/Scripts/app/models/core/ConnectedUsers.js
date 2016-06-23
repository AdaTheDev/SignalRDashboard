(function(core) {
    core.ConnectedUsers = ConnectedUsers;

    function ConnectedUsers() {
        this.numberOfConnectedUsers = 0;
        
        this.updateFromData = function(data) {            
            signalrdashboard.mapping.map(data, this);            
        };
    }
    
})(window.signalrdashboard.core || (window.signalrdashboard.core = {}));