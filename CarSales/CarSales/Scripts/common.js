﻿$(function () {
    $('.content').mouseover(function () {
        $(this).css("cursor", "pointer");
        $(this).animate({ width: "300px" }, 'slow');
    });

    $('.content').mouseout(function () {

        $(this).animate({ width: "200px" }, 'slow');

    });
});