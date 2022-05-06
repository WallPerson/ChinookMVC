// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("[data-toggle=myCollapse]").click(function( ev ) {
    ev.preventDefault();
    var target;
    if (this.hasAttribute('data-target')) {
  target = $(this.getAttribute('data-target'));
    } else {
  target = $(this.getAttribute('href'));
    };
    target.toggleClass("in");
  });