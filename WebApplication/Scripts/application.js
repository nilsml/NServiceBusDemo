(function () {
    var init = function() {
        var emailHub = $.connection.emailHub;

        emailHub.client.emailReceived = function(to, subject, body) {
            var encodedTo = $('<div />').text(to).html();
            var encodedSubject = $('<div />').text(subject).html();
            var encodedBody = $('<div />').text(body).html();

            $('#listOfEmails').append($('<li>' + encodedTo + '&nbsp;' + encodedSubject + '&nbsp;' + encodedBody + '</li>').hide().fadeIn(600));
        };

        $.connection.hub.start().done(function () {
            emailHub.server.connected();
        });
    };

    $(document).ready(init);
})();