(function(signalrdashboard) {
    signalrdashboard.alertHandler = {
        performErrorChecks : function(component, checks) {
            for (var i = 0; i < checks.length; i++) {
                var thisCheck = checks[i];
                var thisModel = thisCheck.model;

                var isError = thisCheck.condition();
                if (isError !== thisModel[thisCheck.targetProperty]) {
                    thisModel[thisCheck.targetProperty] = isError;
                    if (isError) {
                        signalrdashboard.soundPlayer.playError(component);
                    } else {
                        signalrdashboard.soundPlayer.playSuccess(component);
                    }
                }
            }
        }
    };
})(window.signalrdashboard || (window.signalrdashboard = {}));