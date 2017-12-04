$(document).ready(function() {
 var mySwiper = new Swiper ('.main-slider', {
    // Optional parameters
    loop: true,
    // If we need pagination
    autoplay: {
        delay: 10000,
        disableOnInteraction: false,
      },
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
    },

    // Navigation arrows
    // navigation: {
    //   nextEl: '.swiper-button-next',
    //   prevEl: '.swiper-button-prev',
    // }
  });
  var mySwiper1 = new Swiper ('.swiper-container', {
    // Optional parameters
    loop: true,
    // If we need pagination
    autoplay: {
        delay: 10000,
        disableOnInteraction: false,
      },

    // Navigation arrows
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    }
  });

  $( ".magnification" ).click(function(e) {
    var container = $(".searchit");
    if (!container.is(e.target) && container.has(e.target).length === 0) {
      $('.magnification').hide();
      $('ul.tert-nav li').removeClass('search');    }
    });

  //update date tour
  $('#datetimepicker4').datetimepicker({
      format: 'DD/MM/YYYY'
    });
  $('#datetimepicker5').datetimepicker({
      format: 'DD/MM/YYYY'
    });
});

