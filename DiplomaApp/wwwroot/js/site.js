// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    //$('#btnRefugee').click(() => {
    //    $('#btnVolunt').removeClass('active');
    //    $('#formVolunteer').removeClass('open');

    //    $('#btnRefugee').addClass('active');
    //    $('#formRefugee').addClass('open');
    //});

    //$('#btnVolunt').click(() => {
    //    $('#btnRefugee').removeClass('active');
    //    $('#formRefugee').removeClass('open');

    //    $('#btnVolunt').addClass('active');
    //    $('#formVolunteer').addClass('open');
    //});

    $('#btnSend').click(() => {

        let dataHelp = [];
        let hasAnimal = false;
        $('.js-inputCheck').each(function () {
            if ((this).checked) {
                dataHelp.push($(this).val());
            }
        });
        let anim = document.getElementById('inpAnimal');
        if (anim.checked) {
            hasAnimal = true;
        }

        let data = {
            UserName : $('#inpUserName').val(),
            FamilyAmount: $('#inpFamilyCount').val(),
            Helps: dataHelp,
            HasAnimal: hasAnimal
        };

        $.post("/Help/RegisterHelp",
            data,
            function(response) {
                if (response.Success) {
                    alert(`${response.message}`);
                    window.location.href = "/Home";
                }
            });
    });

   


});