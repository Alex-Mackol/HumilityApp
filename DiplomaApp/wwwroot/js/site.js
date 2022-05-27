// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $('#btnRefugee').click(() => {
        $('#btnVolunt').removeClass('active');
        $('#formVolunteer').removeClass('open');

        $('#btnRefugee').addClass('active');
        $('#formRefugee').addClass('open');
    });

    $('#btnVolunt').click(() => {
        $('#btnRefugee').removeClass('active');
        $('#formRefugee').removeClass('open');

        $('#btnVolunt').addClass('active');
        $('#formVolunteer').addClass('open');
    });

});