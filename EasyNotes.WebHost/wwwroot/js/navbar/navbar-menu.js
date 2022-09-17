(function () {
    webApp.namespace("webApp.page.navbarMenu");
    webApp.page.navbarMenu = (function () {
        return {
            showAccount: function showAccountFn() {
                var toggle = $("#notify").css('display');
                if (toggle === 'none') {
                    $("#notify").css('display', 'block')
                    $("#notify").css('animation', 'fadeIn .5s ease');
                }
                else {
                    $("#notify").css('display','none')
                }
            },

            logout: function logoutFn() {
                var url = "/Identity/Account/Logout";
                webApp.helper.request.getAsync(url);
            }
        }
    }());
}());