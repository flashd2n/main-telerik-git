'use strict';

let jukeBox = document.querySelector('ul.player');

jukeBox.addEventListener('click', function (event) {

    let existingAudioPlayer = document.getElementById('player');
    let songName = event.target.dataset.src;
    // let songName = event.target.getAttribute('data-src');

    if (existingAudioPlayer) {

        if (songName === existingAudioPlayer.getAttribute('src')) {

            if (existingAudioPlayer.paused) {
                existingAudioPlayer.play();
                event.target.id = 'playing';
            } else {
                existingAudioPlayer.pause();
                event.target.id = 'paused';
            }

        } else {

            let isPaused = document.querySelector('#paused');

            if (isPaused) {
                document.querySelector('#paused').removeAttribute('id');
            } else {

                document.querySelector('#playing').removeAttribute('id');
            }

            existingAudioPlayer.src = songName;
            existingAudioPlayer.play();
            event.target.id = 'playing';
        }

    } else {

        let audioPlayer = document.createElement('audio');
        audioPlayer.id = 'player';
        event.target.id = 'playing';

        audioPlayer.src = songName;
        document.body.appendChild(audioPlayer);
        audioPlayer.play();


        audioPlayer.addEventListener('ended', function () {

            this.parentNode.removeChild(this);
            event.target.removeAttribute('id');

        }, false);
    }
}, false);