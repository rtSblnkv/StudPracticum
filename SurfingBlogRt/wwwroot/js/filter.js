$(document).ready(function(){
    $(".filter_button").on("click",filtering);
    $(".clear_button").on("click",clearFilters);

    function filtering(){

        var format = $("#filter_format option:selected").text();
        if (format != "Любой"){
            format = format.toUpperCase();
        }

        var language =  $("#filter_language option:selected").text();
        if (language != "Любой"){
            language = language.toUpperCase();
        }

        $(".block").each(function() {
            var text = $(this).contents().text().toUpperCase();
        
            if ( (text.indexOf(format) > -1 || format == "Любой")
                &&  (text.indexOf(language) > -1 || language == "Любой")) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
            });
            return false;

    }

    function showAll(){
        $(".block").each(function() {
            $(this).show();
        });
    }

    function clearFilters(){
        showAll();
        $('#filter_format option').prop('selected', false);
        $('#filter_location option').prop('selected', false);
        $('#filter_language option').prop('selected', false);
    }
});