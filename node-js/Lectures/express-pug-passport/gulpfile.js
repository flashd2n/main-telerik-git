const gulp = require('gulp');
const nodemon = require('gulp-nodemon');

gulp.task('server', () => {
    const connectToDb = require('./app/data/database-connect');
    const setupApp = require('./app/app');
    const dbUrl = 'mongodb://localhost/lecture-auth-sessions';

    connectToDb(dbUrl)
        .then((db) => {
            return setupApp(db);
        })
        .then((app) => {
            app.listen(3001, () => {
                console.log('Server running on port 3001');
            });
        })
        .catch((err) => {
            console.log(err.message);
        });
});

gulp.task('dev', () => {
    return nodemon({
        ext: 'js html',
        script: 'server.js',
    });
});
