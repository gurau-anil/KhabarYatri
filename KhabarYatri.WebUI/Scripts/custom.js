//import { selectors } from "sizzle";

$(function () {
    $(window).bind('scroll', function () {
        if ($(window).scrollTop() > 136) {
            $('.navbar').addClass("navbar-fixed-top");
        }
        else {
            $('.navbar').removeClass("navbar-fixed-top");
        }
    });


    var url = window.location;
    $('.navbar .nav').find('.active').removeClass('active');
    $('.navbar .nav li a').each(function () {
        if (this.href == url) {
            $(this).parent().addClass('active');
        }
    });


    function showTime() {
        // to get current time/ date.
        var date = new Date();
        // to get the current hour
        var h = date.getHours();
        // to get the current minutes
        var m = date.getMinutes();
        //to get the current second
        var s = date.getSeconds();
        // AM, PM setting
        var session = "AM";

        //conditions for times behavior 
        if (h == 0) {
            h = 12;
        }
        if (h >= 12) {
            session = "PM";
        }

        if (h > 12) {
            h = h - 12;
        }
        m = (m < 10) ? m = "0" + m : m;
        s = (s < 10) ? s = "0" + s : s;

        //putting time in one variable
        var time = h + ":" + m + ":" + s + " " + session;
        //putting time in our div
        $('#clock').html(time);
        //to change time in every seconds
        setTimeout(showTime, 1000);
    }
    showTime();

    //$(".glyphicon").click(function () {
    //    $("html, body").animate({ scrollTop: $('.fb-page').offset().top }, 1000);
    //});

    function clearTextArea(data) {
        console.log("clear text area");
        console.log(data);
        $("form").find("#comment-area").val("");
    }

    

});