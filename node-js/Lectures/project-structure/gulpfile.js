const gulp = require('gulp');
const mocha = require('gulp-mocha');
const istanbul = require('gulp-istanbul');

gulp.task('pre-test', () => {
    return gulp.src(['./data/**/*.js',
        './app/**/*.js',
        './config/**/*.js',
        './database/**/*.js',
        './models/**/*.js',
        './validation/**/*.js'])
        .pipe(istanbul({
            includeUntested: true,
        }))
        .pipe(istanbul.hookRequire());
});

gulp.task('test:unit', ['pre-test'], () => {
    return gulp.src('./test/**/*.js')
        .pipe(mocha())
        .pipe(istanbul.writeReports());
});
