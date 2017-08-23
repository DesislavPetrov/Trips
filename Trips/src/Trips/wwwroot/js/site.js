(function () {
    var element = $("#username");
    element.text = "Desislav Petrov";

    var main = $("#main");
    main.on("mouseenter", function(){
            main.style = "background-color: #888";
    });

    main.on("mouseleave", function () {
        main.style = "";
    });
        
    var $sidebarAndWrapper = $("#sidebar, #wrapper");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
    })
})();