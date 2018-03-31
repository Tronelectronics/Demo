$(document).ready(function () {
    /* ======= Scrollspy ======= */
    $('body').scrollspy({ target: '#page-nav-wrapper', offset: 100 });
    /* ======= ScrollTo ======= */
    $('.scrollto').on('click', function (e) {
        //store hash
        var target = this.hash;
        e.preventDefault();
        $('body').scrollTo(target, 800, { offset: -60, 'axis': 'y' });
    });
    /* ======= Fixed page nav when scrolled ======= */
    $(window).on('scroll resize load', function () {
        $('#page-nav-wrapper').removeClass('fixed');
        var scrollTop = $(this).scrollTop();
        var topDistance = $('#page-nav-wrapper').offset().top;
        if ((topDistance) > scrollTop) {
            $('#page-nav-wrapper').removeClass('fixed');
            $('body').removeClass('sticky-page-nav');
        }
        else {
            $('#page-nav-wrapper').addClass('fixed');
            $('body').addClass('sticky-page-nav');
        }
    });
    /* ======= Chart ========= */
    $('.chart').easyPieChart({
        barColor: '#8BC34A',//Pie chart colour
        trackColor: '#e8e8e8',
        scaleColor: false,
        lineWidth: 5,
        animate: 2000,
        onStep: function (from, to, percent) {
            $(this.el).find('span').text(Math.round(percent));
        }
    });
});