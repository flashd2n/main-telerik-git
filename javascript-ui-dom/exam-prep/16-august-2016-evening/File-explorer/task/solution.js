'use strict';

function solve() {
    return function (fileContentsByName) {

        $(document.body).on('click', '.item-name', function (event) {

            var $parent = $(this).parent();

            if ($parent.hasClass('dir-item')) {

                $parent.toggleClass('collapsed');

            }
            var itemHTML = $(this).html();
            $('.file-content').text(fileContentsByName[itemHTML]);
        });

        $(document.body).on('click', '.del-btn', function () {
            var $parent = $(this).parent();
            $parent.detach();

        });


        var addButton = $('.add-btn');
        addButton.click(function () {

            $(this).removeClass('visible');
            $(this).siblings('input[type=text]').addClass('visible');

        });

        var inputField = $('input[type=text]');
        var $root = $('ul.items');
        var $deleteButton = $('<a class="del-btn">');
        var $item = $('<a class="item-name">');
        var $fileLi = $('<li class="file-item item">');
        var $directories = $('.dir-item');

        inputField.on('keypress', function (event) {

            if (event.key === 'Enter') {

                var fileName = $(this).val();
                var dirSeparator = fileName.indexOf('/');
                if (dirSeparator === -1) {
                    $item.append(fileName);
                    $fileLi.append($item).append($deleteButton);
                    $root.append($fileLi);
                } else {

                    var fileData = fileName.split('/');
                    var fileDir = fileData[0];
                    fileName = fileData[1];

                    $directories.each(function (index, directory) {

                        var $directory = $(directory);

                        var directoryName = $directory.children('a.item-name').html();

                        if (directoryName === fileDir) {
                            $item.append(fileName);
                            $fileLi.append($item).append($deleteButton);
                            $directory.children('ul.items').append($fileLi);
                        }
                    });
                }
                
                $(this).removeClass('visible');
                $(this).siblings('a.add-btn').addClass('visible');
            }
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}