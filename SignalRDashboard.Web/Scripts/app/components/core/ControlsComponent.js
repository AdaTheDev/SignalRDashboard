(function (signalrdashboardCore) {
    signalrdashboardCore.ControlsComponent =
       ng.core.Component({
          selector: 'controls',
          templateUrl: '/scripts/app/templates/core/ControlsComponent.html'
       })
       .Class({
          constructor: function() {              
          },
           ngOnInit: function() {
               bindEvents();
           }
      });

    function bindEvents() {
        $("#mutetogglebutton").on("click", toggleMute);
        $("#stopsoundbutton").on("click", stopSound);
    }

    function toggleMute() {
        if ($(this).attr("data-is-muted") === "true") {
            signalrdashboard.soundPlayer.unmute();
            $(this).attr("data-is-muted", "false");
            $(this).attr("src", "../../content/images/unmute.png");
        } else {
            signalrdashboard.soundPlayer.mute();
            $(this).attr("data-is-muted", "true");
            $(this).attr("src", "../../content/images/mute.png");
        }
    }

    function stopSound() {
        signalrdashboard.soundPlayer.silence();
    }
})(window.signalrdashboard.core || (window.signalrdashboard.core = {}));