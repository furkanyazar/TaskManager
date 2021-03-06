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
                    url: "/Task/AddDaily",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemDaily.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-pencil'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputDaily.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata olu?tu", "error");
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
                    url: "/Task/AddWeekly",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemWeekly.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-pencil'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputWeekly.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata olu?tu", "error");
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
                    url: "/Task/AddMonthly",
                    type: "post",
                    data: task,
                    success: function (response) {
                        if (response.success) {
                            todoListItemMonthly.append("<li value='" + response.id + "'><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='update mdi mdi-pencil'></i><i class='remove mdi mdi-close-circle-outline ml-1'></i></li>");
                            todoListInputMonthly.val("");
                        } else {
                            swal("", response.message, "error");
                        }
                    },
                    error: function () {
                        swal("", "Bir hata olu?tu", "error");
                    }
                });
            }
        });

        todoListItem.on('change', '.checkbox', function () {
            var itemToChange = $(this);

            $.ajax({
                url: "/Task/Succeed?id=" + itemToChange.parent().parent().parent().val(),
                type: "post",
                success: function (response) {
                    if (response.success) {
                        if (itemToChange.attr('checked')) {
                            itemToChange.removeAttr('checked');
                        } else {
                            itemToChange.attr('checked', 'checked');
                        }

                        itemToChange.closest("li").toggleClass('completed');
                    } else {
                        swal("", response.message, "error");
                    }
                },
                error: function () {
                    swal("", "Bir hata olu?tu", "error");
                }
            });
        });

        todoListItem.on('click', '.remove', function () {
            swal({
                text: "G?rev silinsin mi?",
                icon: "warning",
                buttons: ["?ptal", "Tamam"],
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {
                    var itemToDelete = $(this).parent();

                    $.ajax({
                        url: "/Task/Delete?id=" + itemToDelete.val(),
                        type: "post",
                        success: function (response) {
                            if (response.success) {
                                itemToDelete.remove();
                            } else {
                                swal("", response.message, "error");
                            }
                        },
                        error: function () {
                            swal("", "Bir hata olu?tu", "error");
                        }
                    });
                }
            });
        });

    });
})(jQuery);