function startCountdown(timeLeft) {
        var interval = setInterval( countdown, 1000 );
        update();

        function countdown() {
            if ( --timeLeft > 0 ) {
                update();
            } else {
                clearInterval( interval );
                update();
                completed();
            }
        }

        function update() {
            hours   = Math.floor( timeLeft / 3600 );
            minutes = Math.floor( ( timeLeft % 3600 ) / 60 );
            seconds = timeLeft % 60;

            document.getElementById('time-left').innerHTML = '' + hours + ':' + minutes + ':' + seconds;
        }

        function completed() {
            window.location = "http://localhost:50618/timeOver.aspx";
        }
    }