(function (global) {
    var map = {
        'app':  './app/scripts/',
        'rxjs': 'node_modules/rxjs',
        'angular2-in-memory-web-api':   'node_modules/angular2-in-memory-web-api',
        '@angular': 'node_modules/@angular',
        'components': './app/components'
    };
    //packages tells the system loader how to load when no filename and/or no extension
    var packages = {
        'app':  {main: 'boot.js', defaultExtension: 'js'},
        'rxjs': {defaultExtension: 'js'},
        'angular2-in-memory-web-api':   {defaultExtension: 'js'},
        'components' : {defaultExtension: 'js'}
    };
    
    var packageNames = [
    '@angular/common',
    '@angular/compiler',
    '@angular/core',
    '@angular/http',
    '@angular/platform-browser',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    '@angular/router-deprecated',
    '@angular/testing',
    '@angular/upgrade',
  ];
  // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
  packageNames.forEach(function(pkgName){
      packages[pkgName] = {main: 'index.js', defaultExtension: 'js'};
  });
  var config = {
      map: map,
      packages: packages,
      traceurOptions: {
          annotations: true,
          types: true,
          memberVariables: true
      }
  }
  
  if(global.filterSystemConfig){global.filterSystemConfig(config); }
   
   System.config(config);
})(this);