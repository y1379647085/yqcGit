//$(function () {
//    $("#album-list img").mouseover(function () {
//        $(this).animate({ height: '+=25', width: '+=25' })
//               .animate({ height: '-=25', width: '-=25' });
//    });
//});
$(function () {
    $("#album-list img").mouseover(function () {
        $(this).effect("bounce", { time: 3, distance: 40 });
    });
});