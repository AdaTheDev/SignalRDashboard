(function(signalrdashboard) {
    //var _modelErrorPropertyStates = {};
    //var ErrorStates = {
    //    NoChange: 0,
    //    Warning: 1,
    //    Error: 2,
    //    Success: 3
    //};

    //function checkEffectiveErrorState(model, targetProperty, newState) {
    //    var fullyQualifiedProperty = model.modelType + '.' + targetProperty;

    //    if (!_modelErrorPropertyStates.hasOwnProperty(fullyQualifiedProperty)) {
    //        _modelErrorPropertyStates[fullyQualifiedProperty] = newState;
    //        return newState;
    //    }  

    //    if (!_modelErrorPropertyStates[fullyQualifiedProperty] !== newState) {
    //        _modelErrorPropertyStates[fullyQualifiedProperty] = newState;
    //        return newState;
    //    }

    //    return ErrorStates.NoChange;
    //}

    signalrdashboard.mapping = {
        map : function(source, destination) {
            for (var i in source) {
                if (destination.hasOwnProperty(i)) {
                    destination[i] = source[i];
                }
            }
        }
    };
})(window.signalrdashboard || (window.signalrdashboard = {}));