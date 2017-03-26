$(document).ready(function () {

    $.connection.hub.start();

    var statistics = $.connection.statisticsHub;
    statistics.client.updateAdsCount = updateCount;
});

function updateCount(count) {
    console.log('tuka')
    $('#ads-count').text(count);
}