(function () {
    webApp.namespace("webApp.page.userManagementInfo");
    webApp.page.userManagementInfo = (function () {
        return {
            confirmCancel: function confirmCancelFn() {
                var url = '/Settings/UserManagement/Info';
                window.webApp.global.showConfirmModal('Confirm', webApp.constant.MESSAGE.cancelConfirmMessage, function yesCallback() {
                    window.location.href = url;
                })
            }
        }
    }());
}());

$(function () {

})