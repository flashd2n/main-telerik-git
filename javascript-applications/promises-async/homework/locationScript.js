    (function () {
        'use strict';

        let container = document.getElementById('root');

        if (!navigator.geolocation) {
            container.innerHTML = 'Your browser does not support geolocation';
            return;
        }


        let getLocation = function () {

            let options = {
                enableHighAccuracy: true
            };

            return new Promise(function (resolve, reject) {

                navigator.geolocation.getCurrentPosition(function (position) {

                    resolve(position);

                }, function (error) {

                    reject(error);

                }, options);
            });

        };

        getLocation().then(geolocationSuccess, geolocationFail);


        function geolocationSuccess(position) {

            let mapImage = document.createElement('img');
            mapImage.src = 'https://maps.googleapis.com/maps/api/staticmap?center=' + position.coords.latitude + ',' + position.coords.longitude + '&zoom=13&size=500x400&sensor=false&markers=' + position.coords.latitude + ',' + position.coords.longitude;
            container.appendChild(mapImage);

        }

        function geolocationFail(error) {
            container.innerHTML = `An error occured. <br />
Error code: ${error.code} <br />
Error message: ${error.message}`;
        }


    })();
