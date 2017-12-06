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

  //mobile-menu
  $("#my-menu").mmenu();
  var API = $("#my-menu").data( "mmenu" );
  $(".mobile-menu .text-left #primary-menu").click(function() {
    API.open();
  });
  //search button
  var isOpen = false;
  $(".icon-search-menu .wicon").click(function(){
      // $("div.hide-search").removeClass('hide-search').addClass('unhide-search');
    if(isOpen == false){
      $("#searchBox").removeClass('hide-search').addClass('unhide-search');
      // inputBox.focus();
      isOpen = true;
    } else {
      $("#searchBox").removeClass('unhide-search').addClass('hide-search');
      // inputBox.focusout();
      isOpen = false;
    }
  });
  $(document).click(function (e)
  {
    var container = $(".icon-search-menu .wicon")
    if (!container.is(e.target) && container.has(e.target).length === 0)
    {
      // $('#searchbox').hide();
      $("#searchBox").removeClass('unhide-search').addClass('hide-search');
    }
  });

  var isOpen = false;
  $(".icon-search-menu .wicon1").click(function(){
      // $("div.hide-search").removeClass('hide-search').addClass('unhide-search');
    if(isOpen == false){
      $("#searchBox1").removeClass('hide-search').addClass('unhide-search');
      // inputBox.focus();
      isOpen = true;
    } else {
      $("#searchBox1").removeClass('unhide-search').addClass('hide-search');
      // inputBox.focusout();
      isOpen = false;
    }
  });
  $(document).click(function (e)
  {
    var container = $(".icon-search-menu .wicon1")
    if (!container.is(e.target) && container.has(e.target).length === 0)
    {
      // $('#searchbox').hide();
      $("#searchBox1").removeClass('unhide-search').addClass('hide-search');
    }
  });
  //update date tour
  $('#datetimepicker4').datetimepicker({
      format: 'DD/MM/YYYY'
    });
  $('#datetimepicker5').datetimepicker({
      format: 'DD/MM/YYYY'
    });
});

