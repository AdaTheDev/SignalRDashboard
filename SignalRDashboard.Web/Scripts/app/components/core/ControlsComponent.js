(function (signalrdashboardCore) {
    var _$muteToggleButton;
    signalrdashboardCore.ControlsComponent =
       ng.core.Component({
          selector: 'controls',
          templateUrl: '/scripts/app/templates/core/ControlsComponent.html'
       })
       .Class({
          constructor: function() {              
          },
           ngOnInit: function() {
               _$muteToggleButton = $("#mutetogglebutton");
               bindEvents();
               if (Cookies.get("soundMuted") === 'true') {
                   mute();
               }
           }
      });

    function bindEvents() {
        _$muteToggleButton.on("click", toggleMute);
        $("#stopsoundbutton").on("click", stopSound);
    }

    function unmute() {
        signalrdashboard.soundPlayer.unmute();
        _$muteToggleButton.attr("data-is-muted", "false");
        _$muteToggleButton.attr("src", "../../content/images/unmute.png");
        Cookies.set("soundMuted", false);
    }

    function mute() {
        signalrdashboard.soundPlayer.mute();
        _$muteToggleButton.attr("data-is-muted", "true");
        _$muteToggleButton.attr("src", "../../content/images/mute.png");
        Cookies.set("soundMuted", true);    
    }

    function toggleMute() {
        if ($(this).attr("data-is-muted") === "true") {
            unmute();
        } else {
            mute();
        }
    }

    function stopSound() {
        signalrdashboard.soundPlayer.silence();
    }
})(window.signalrdashboard.core || (window.signalrdashboard.core = {}));