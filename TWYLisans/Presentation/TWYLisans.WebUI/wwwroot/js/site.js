//var aContainer = document.getElementById("myDIV");

//// Get all buttons with class="btn" inside the container
//var alinks = aContainer.getElementsByClassName("list-group-item-action");

//// Loop through the buttons and add the active class to the current/clicked button
//for (var i = 0; i < alinks.length; i++) {
//    alinks[i].addEventListener("click", function () {
//        var current = document.getElementsByClassName("active");
//        current[0].className = current[0].className.replace("active", "");
//        this.className += "active";
//    });
//}

var aNavLinks = document.querySelectorAll(".list-group-item-action");

aNavLinks.forEach(aNavLink => {
    aNavLink.addEventListener("click", () => {
        document.querySelector(".active")?.classList.remove("active");
        aNavLink.classList.add("active");
    })
});


// Example starter JavaScript for disabling form submissions if there are invalid fields
(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()
function generateGUID() {
    var d = new Date().getTime();
    var uuid = 'yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });

    return uuid;

};


function myFunction() {
    document.getElementById("myGuid").textContent = generateGUID().toUpperCase();
}