$(document).ready(function(){
    $(".dropdown-trigger").dropdown({
        hover : true,
        inDuration : 500
    });
    $('.tooltipped').tooltip();
    $('.sidenav').sidenav();
    $('.tabs').tabs();
    $('select').formSelect();
    $('.collapsible').collapsible();
    $('.modal').modal();
});