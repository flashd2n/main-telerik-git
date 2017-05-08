'use strict';

import requester from 'requester';

const cachedTemplates = {};

function loadTemplate(templateName) {

    if (cachedTemplates.hasOwnProperty(templateName)) {

        return Promise.resolve(cachedTemplates[templateName]);

    }

    return requester.get(`templates/${templateName}.handlebars`)
        .then(function (template) {

            const renderer = Handlebars.compile(template);

            cachedTemplates[templateName] = renderer;

            return Promise.resolve(renderer);

        });
}

export {
    loadTemplate
};
