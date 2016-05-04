/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
ts = require('gulp-typescript');

gulp.task('default', ['ts']);

gulp.task('ts', function () {
    return gulp.src(['./app/scripts/*.ts'])
        .pipe(ts({
            module: 'commonjs',
            experimentalDecorators: true
        })).js.pipe(gulp.dest('./app/scripts/*.ts'));
});