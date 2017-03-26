$(window).endlessScroll({
    inflowPixels: 300,
    callback: function () {
        var page = Math.ceil($('.image-tile.outer-title.text-center').length / 5);
        var url = window.location.href;
        var obj = url.split("?")[1];
        var getUrl = '/Rims/SearchingNextFive?' + obj + '&page=' + page;
        $.ajax({
            url: getUrl,
            method: 'GET',
            success: function (result) {
                $('.holder .container').append(result);
            }
        });
    }
});