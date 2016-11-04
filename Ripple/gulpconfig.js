module.exports = {    
    gitbranch: 'master',
	isProduction: process.env.NODE_ENV === 'production', //From Windows command line:SET NODE_ENV=production. MAC: EXPORT NODE_ENV=production
	webroot: './',
	scssSource: './components/scss/main.scss',
	cssFileName: 'search.css',
	jsSource: [
        './components/scripts/search.base.js',
        './components/scripts/search.results.js',
        './components/scripts/search.details.js',
		'./components/scripts/search.onready.js'       
	],
	jsFileName: 'search.js',
    banner: ['/**',
            ' * <%= package.name %> - <%= package.description %>',
            ' * @version v<%= package.version %>',
            ' * @link <%= package.repository.url %>',
            ' * @author <%= package.author %>',
            ' * Copyright ' + new Date().getFullYear() + '. <%= package.license %> licensed.',
            ' * Built: ' + new Date() + '.',
            ' */',
            ''
    ].join('\n')
};
