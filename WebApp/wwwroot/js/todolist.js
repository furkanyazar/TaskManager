(function ($) {
    'use strict';
    $(function () {
        var todoListItem = $('.todo-list');

        var todoListItemDaily = $('ul[name="daily"]');
        var todoListInputDaily = $('input[name="daily"]');

        $('button[name="daily"]').on("click", function (event) {
            event.preventDefault();

            var item = $(this).prevAll('input[name="daily"]').val();

            if (item) {
                var task = {
                    Description: item,
                    TaskTypeId: 1
                };

                $.ajax({
                    url: "/Task/Add",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemDaily.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-rename-box'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputDaily.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata oluþtu", "error");
                    }
                });
            }
        });

        var todoListItemWeekly = $('ul[name="weekly"]');
        var todoListInputWeekly = $('input[name="weekly"]');

        $('button[name="weekly"]').on("click", function (event) {
            event.preventDefault();

            var item = $(this).prevAll('input[name="weekly"]').val();

            if (item) {
                var task = {
                    Description: item,
                    TaskTypeId: 2
                };

                $.ajax({
                    url: "/Task/Add",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemWeekly.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-rename-box'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputWeekly.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata oluþtu", "error");
                    }
                });
            }
        });

        var todoListItemMonthly = $('ul[name="monthly"]');
        var todoListInputMonthly = $('input[name="monthly"]');

        $('button[name="monthly"]').on("click", function (event) {
            event.preventDefault();

            var item = $(this).prevAll('input[name="monthly"]').val();

            if (item) {
                var task = {
                    Description: item,
                    TaskTypeId: 3
                };

                $.ajax({
                    url: "/Task/Add",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemMonthly.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-rename-box'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputMonthly.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata oluþtu", "error");
                    }
                });
            }
        });

        todoListItem.on('change', '.checkbox', function () {
            if ($(this).attr('checked')) {
                $(this).removeAttr('checked');
            } else {
                $(this).attr('checked', 'checked');
            }

            $(this).closest("li").toggleClass('completed');

        });

        todoListItem.on('click', '.remove', function () {
            swal({
                text: "Görev silinsin mi?",
                icon: "warning",
                buttons: ["Ýptal", "Tamam"],
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {
                    var itemToDelete = $(this).parent();

                    $.ajax({
                        url: "/Task/Delete?id=" + $(this).parent().val(),
                        type: "post",
                        success: function (response) {
                            if (response.success) {
                                itemToDelete.remove();
                            } else {
                                swal("", response.message, "error");
                            }
                        },
                        error: function () {
                            swal("", "Bir hata oluþtu", "error");
                        }
                    });
                }
            });
        });

    });
})(jQuery);