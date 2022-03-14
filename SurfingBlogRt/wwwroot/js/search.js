
document.querySelector(".search_input").addEventListener('keyup', () => {

    var search_line = $(".search_input");
    var search_value = search_line.val().toUpperCase();
  
    $(".block").each(function() {
  
      var text = $(this).contents().text().toUpperCase();
  
      if (search_value !== "" && text.indexOf(search_value) == -1) {
          $(this).hide();
      }
      else {
          $(this).show();
      }
      });
  });
   
 