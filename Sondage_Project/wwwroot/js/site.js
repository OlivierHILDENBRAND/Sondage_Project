let count = 1;
$(document).ready(function () {
    $(".answer").hide();
});

$("#add_answer").click(function () {
    count = count + 1;
    if (count == 2) {
        $("#answer3").show();
    }
    else if (count == 3) {
        $("#answer4").show();
        $("#add_answer").hide();
    }

});