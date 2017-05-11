//$(".nav a").on("click", function () {
//    $(".nav").find(".active").removeClass("active");
//    $(this).parent().addClass("active");
//});

$(window).on("scroll", function () {
    $('nav').toggleClass('navbar-fixed-top', $(this).scrollTop() > 200);
    $('#aboutMe').toggleClass('aboutMeNotScrolled', $(this).scrollTop() <= 200);
    $('#aboutMe').toggleClass('aboutMeScrolled', $(this).scrollTop() > 200);
});

var fbook = function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/il_HE/sdk.js#xfbml=1&version=v2.8";
    fjs.parentNode.insertBefore(js, fjs);
}
fbook(document, 'script', 'facebook-jssdk');

$(function () {
    var ajaxPostsSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        $.ajax(options).done(function (data) {
            var $targetElement = $($form.attr("data-mo-target"));
            $targetElement.replaceWith(data);
        });
        return false;
    };
    $("form[data-mo-ajax='true']").submit(ajaxPostsSubmit);
});
