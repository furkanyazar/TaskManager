(function ($) {
    'use strict';
    var todoListItem = $(".todo-list");

    todoListItem.on('click', '.update', function () {
        var itemToEdit = $(this).parent();

        swal({
            text: 'Görev Düzenle',
            content: {
                element: 'input',
                attributes: {
                    defaultValue: itemToEdit.get(0).innerText,
                }
            },
            button: {
                text: "Kaydet",
                closeModal: false,
            },
        }).then(name => {
            if (!name) throw null;

            var task = {
                Description: name,
                TaskId: itemToEdit.val(),
            };

            $.ajax({
                url: "/Task/Update",
                type: "post",
                data: task,
                success: function (response) {
                    if (response.success) {
                        if (response.status) {
                            itemToEdit.get(0).innerHTML = "<div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox' checked/>" + name + "<i class='input-helper'></i></label></div><i class='update mdi mdi-pencil'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i>";
                        } else {
                            itemToEdit.get(0).innerHTML = "<div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + name + "<i class='input-helper'></i></label></div><i class='update mdi mdi-pencil'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i>";
                        }

                        swal.close();
                    } else {
                        swal("", response.message, "error");
                    }
                },
                error: function () {
                    swal("", "Bir hata oluþtu", "error");
                }
            });
        }).catch(err => {
            swal.close();
        });;
    });
})(jQuery);