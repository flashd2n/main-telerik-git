SystemJS.config({
    transpiler: 'plugin-babel',
    map: {
        // system js files
        'plugin-babel': 'libs/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': 'libs/systemjs-plugin-babel/systemjs-babel-browser.js',

        // app files
        'app': 'js/app.js',
        'myRouter': 'js/router.js',
        'templates': 'js/templates.js',
        'requester': 'js/requester.js',
        'data': 'js/data.js',
        'homeController': 'js/controllers/home.js',
        'myCookieController': 'js/controllers/myCookie.js',
        'userController': 'js/controllers/user.js',
    }
});

System.import('app');
