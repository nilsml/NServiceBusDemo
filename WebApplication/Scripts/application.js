(function () {
    var init = function() {
        var emailHub = $.connection.emailHub;

        emailHub.client.broadcastMessage = function(to, subject, body) {
            var encodedTo = $('<div />').text(to).html();
            var encodedSubject = $('<div />').text(subject).html();
            var encodedBody = $('<div />').text(body).html();

            $('#listOfEmails').append('<li>' + encodedTo + '&nbsp;' + encodedSubject + '&nbsp;' + encodedBody + '</li>');
        };

        $.connection.hub.start();
    };

    $(document).ready(init);
})();