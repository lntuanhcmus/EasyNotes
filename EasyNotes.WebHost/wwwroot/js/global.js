(function () {
    webApp.namespace("webApp.global");
    webApp.global = (function () {
        return {
            showConfirmModal: function showConfirmModalFn(title, message, yesCallback, noCallback) {
                var modal = $('#modal_confirm')

                modal.find('.modal-header .modal-title').html(title);
                modal.find('.modal-body .modal-message').html(message);

                var btnYes = modal.find('button[ui-action="yes"]');
                if (btnYes) {
                    btnYes.unbind("click");
                    btnYes.bind("click", function(){
                        modal.modal('hide');
                        if (typeof(yesCallback === 'function')) {
                            yesCallback();
                        }
                    });
                }

                var btnNo = modal.find('button[ui-action="no"]');
                if (btnNo) {
                    btnNo.unbind("click");
                    btnNo.bind("click", noCallback);
                }

                modal.modal('show');
            }
        }
    }())
}());