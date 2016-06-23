(function(signalrdashboard) {
    var _soundCurrentlyPlayingCategory;
    var _soundIsPlaying = false;
    var _soundCurrentlyPlayingAudio;
    var _mute = false;
    var _minSecondsBetweenSounds = 5;
    var _earliestNextSoundAllowed = new Date(1, 1, 1);

    var SoundCategory = {
        Error: "Error",
        Success: "Success"
    };

    function onSoundFinishedPlaying() {
        _soundIsPlaying = false;
        _earliestNextSoundAllowed = new Date();
        _earliestNextSoundAllowed.setSeconds(_earliestNextSoundAllowed.getSeconds() + _minSecondsBetweenSounds);
        
        _soundCurrentlyPlayingAudio = null;
        _soundCurrentlyPlayingCategory = "";
    };

    function stopSound() {
        if (_soundIsPlaying && _soundCurrentlyPlayingAudio != null) {
            try {
                _soundCurrentlyPlayingAudio.pause();
            }
            catch(e) {};

            _soundIsPlaying = false;
            _soundCurrentlyPlayingAudio = null;
        }
    }

    function playSound(file, category) {
        if (_mute) return;

        if (_soundIsPlaying) {
          if (_soundCurrentlyPlayingCategory !== SoundCategory.Error && category === SoundCategory.Error) {
              stopSound();
              _earliestNextSoundAllowed = new Date(1, 1, 1);
          }
        }

        if (!_soundIsPlaying && (_earliestNextSoundAllowed <= new Date())) {
            var audio = new Audio(file);
            audio.onended = onSoundFinishedPlaying;
            _soundIsPlaying = true;
            _soundCurrentlyPlayingCategory = category;
            _soundCurrentlyPlayingAudio = audio;
            _soundCurrentlyPlayingAudio.play();
        }
    }

    function canPlaySound(category) {
        if (_mute) return false;

        if (_soundIsPlaying && (_soundCurrentlyPlayingCategory === SoundCategory.Error || _soundCurrentlyPlayingCategory === category)) return false;

        if (!_soundIsPlaying && (_earliestNextSoundAllowed <= new Date())) return true;

        return false;
    }

    signalrdashboard.soundPlayer = {
        playError : function(component) {
            if (canPlaySound(SoundCategory.Error)) {
                $.get("Media/GetRandomErrorSound", { component: component }, function(response) {
                    playSound(response, SoundCategory.Error);
                });
            }
        },

        playSuccess : function(component) {
            if (canPlaySound(SoundCategory.Success)) {
                $.get("Media/GetRandomSuccessSound", { component: component }, function(response) {
                    playSound(response, SoundCategory.Success);
                });
            }
        },
        
        silence: stopSound,

        mute : function() {
            _mute = true;
            stopSound();
        },

        unmute : function() {
            _mute = false;
        }
    };
})(window.signalrdashboard || (window.signalrdashboard = {}));