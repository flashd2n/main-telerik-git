'use strict';

(function ($) {

    $.fn.insertCaption = function (options) {

        let opts = $.extend({
            wrapperTag: 'div',
            wrapperClass: 'captioned-image',
            captionTag: 'span',
            captionClass: 'caption'
        }, options);

        return this.each(function () {

            let $img = $(this);

            if ($img.parent(`.${opts.wrapperClass}`).length === 0) {
                $img.wrap(`<${opts.wrapperTag} class="${opts.wrapperClass}"></${opts.wrapperTag}>`)
                    .after(`<${opts.captionTag} class="${opts.captionClass}">${$img.attr('title')}</${opts.captionTag}>`);
            }

        });



    };

}(jQuery));