// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$.ajax({
    url: "https://app.asana.com/-/api/0.1/workspaces/",
    type: 'GET',
    success: function (res) {
        console.log(res);
        alert(res);
    }
});