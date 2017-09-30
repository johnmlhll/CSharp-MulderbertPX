/**
 * Function 1 - Slideshow function for home gallery on main page
 */
$(document).ready(function () {
    $("#home_gallery > img:gt(0)").hide();
    setInterval(function () {
        $('#home_gallery > img:first').fadeOut(1000).next().fadeIn(1000).end().appendTo('#home_gallery');
    }, 4000);
});
/**
 * Function 2 - Function on Contacts page for expanding the FAQ answers when the question are clicked upon
 */
$(document).ready(function slider () {
    $(".answer").hide();
    $(".question").click(function () {
        $(this).next("p").slideToggle(500);
    });
});
/**
 * Function 3 - Function for making buttons available for submission if the validation is wrong on all form buttons
 */
$(document).on('invalid-form.validate', 'form', function () {
    var button = $(this).find('input[type="submit"]');
    setTimeout(function () {
        button.remoteAttr('disabled');
    }, 1);
});
/**
 *Function 4 - adding disabled button feature when submitted so double submits cannot be done
 */
$(document).on('submit', 'form', function () {
    var button = $(this).find('input[type="submit"]');
    setTimeout(function () {
        button.attr('disabled', 'disabled')
    }, 0);
});

/**
 * Function 5 - open when someone clicks on the span element
 */
function openNav() {
    document.getElementById("responsive_nav_wrapper").style.width = "100%";
    document.getElementById("btnOpen").style.display = "none";
}

/**
 * Function 6 - Close when someone clicks on the "x" symbol inside the overlay
 */
function closeNav() {
    document.getElementById("responsive_nav_wrapper").style.width = "0%";
    document.getElementById("btnOpen").style.display = "block";

}