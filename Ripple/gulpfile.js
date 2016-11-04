/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
	del = require('del'),
	chalk = require('chalk'),
	bgred = chalk.gray.bgRed,
	red = chalk.red,

	rename = require('gulp-rename'),
	gulpif = require('gulp-if'),

	sass = require('gulp-sass'),
	sourcemaps = require('gulp-sourcemaps'),

	uglify = require('gulp-uglify'),
	jshint = require('gulp-jshint'),
	jshintStylish = require('jshint-stylish'),
	header = require('gulp-header'),
	concat = require('gulp-concat'),
	
	pkg = require('./package.json'),
    config = require('./gulpconfig.js');

gulp.task('setProductionFromVS', function () {   
    config.isProduction = true;
});

gulp.task('clean-libs', function () {
    return del([config.webroot + '/libs/**']);
});

gulp.task('clean-css', function () {
    return del([config.webroot + '/content/styles/**']);
});

gulp.task('clean-js', function () {
    return del([config.webroot + '/content/scripts/**']);
});

gulp.task('copy-libs', ['clean-libs'], function (callback) {
    gulp.src(["./node_modules/jquery/dist/*.*"])
		.pipe(gulp.dest(config.webroot + '/Libs/jquery'));

    gulp.src(["./node_modules/jquery-ui/jquery-ui.js"])
		.pipe(gulp.dest(config.webroot + '/Libs/jquery-ui'));

    gulp.src(["./node_modules/bootstrap/dist/css/*.*"])
		.pipe(gulp.dest(config.webroot + '/Libs/bootstrap/css'));

    gulp.src(["./node_modules/bootstrap/dist/js/*.*"])
		.pipe(gulp.dest(config.webroot + '/Libs/bootstrap/js'));

    gulp.src(["./node_modules/font-awesome/fonts/*.*"])
		.pipe(gulp.dest(config.webroot + '/Libs/font-awesome/fonts'));

    gulp.src(["./node_modules/font-awesome/css/*.*"])
		.pipe(gulp.dest(config.webroot + '/Libs/font-awesome/css'));

    callback();
    //return merge(jquery, tethercss, tetherjs, bootstrapcss, bootstrapjs, fafonts, facss); 
});

gulp.task('build-css', ['clean-css', 'copy-libs'], function () {
    var outputStyle = config.isProduction ? "compressed" : "expanded"; // See node-sass options for this. https://github.com/sass/node-sass#options

    return gulp.src(config.scssSource)
		.pipe(sourcemaps.init())
		.pipe(sass({ outputStyle: outputStyle })
			.on('error', sass.logError))
		.pipe(sourcemaps.write())
		.pipe(rename(config.cssFileName))
		.pipe(rename({ suffix: "-" + config.gitbranch }))
		.pipe(gulpif(config.isProduction, rename({ suffix: ".min" })))
		.pipe(gulp.dest(config.webroot + '/content/styles'));
		
});

gulp.task('build-js', ['clean-js', 'copy-libs'], function () {
    return gulp.src(config.jsSource)
		.pipe(jshint()) 	//get our config from package.json
		.pipe(jshint.reporter(jshintStylish, { verbose: true })) //report in pretty colors
		//.pipe(jshint.reporter('fail')) //if linting fails. Fail the build.		
		.pipe(concat(config.jsFileName))	//if the js passes linting then concat them 		
		.pipe(gulpif(config.isProduction, uglify())) //if production then compress it.		
		.pipe(header(config.banner, { 'package': pkg })) //add our commented headers.
		.pipe(rename({ suffix: "-" + config.gitbranch }))
		.pipe(gulpif(config.isProduction, rename({ suffix: ".min" })))
		.pipe(gulp.dest(config.webroot + '/content/scripts'));
});


gulp.task('default', [ /*'setProductionFromVS',*/ 'clean-libs', 'copy-libs', 'build-css', 'build-js'], function () {
    if (!config.isProduction) {
        console.log(red("WORKING ON DEVELOPMENT BUILD!"));
    }
    else {
        console.log(red("WORKING ON PRODUCTION BUILD! Make sure _layout has .min"));
    }
});