const gulp = require('gulp');
const nodemon = require('gulp-nodemon');

gulp.task('server', () => {
    const { app } = require('./app');

    app.listen(3001, () => {
        console.log('Server running on port 3001');
    });
});

gulp.task('dev', () => {
    return nodemon({
        ext: 'js html',
        script: 'server.js',
    });
});
