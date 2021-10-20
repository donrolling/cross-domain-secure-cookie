# NgCookieExample

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.2.10.

## Development server

Run `ng serve --ssl` for a dev server. Navigate to `https://localhost:4200/`. The app will automatically reload if you change any of the source files.

Note: must run this site over ssl

### Angular SSL Setup:

add these settings to the angular.json file on this property path: "projects" > "ng-cookie-example" > "architect" > "serve" > "options" 

"options": {
	"sslKey": "certificate/server.key",
	"sslCert": "certificate/server.crt"
},

Note: the path to localserver.key and localserver.crt is relative to the angular.json file. I keep those at the root.

### Generate Certificate:

Use Bash for Windows - this should have come with your Git install

Reference: https://devcenter.heroku.com/articles/ssl-certificate-self

openssl genrsa -aes256 -passout pass:gsahdg -out server.pass.key 4096
openssl rsa -passin pass:gsahdg -in server.pass.key -out server.key
rm server.pass.key
openssl req -new -key server.key -out server.csr
openssl x509 -req -sha256 -days 365 -in server.csr -signkey server.key -out server.crt

#### Install certificate on your machine

Windows Explorer: right-click the certificate/server.crt file and select "install certificate"

https://user-images.githubusercontent.com/1778167/138150756-7ee61171-d278-47bf-8031-70d1acd9ed54.jpg

https://user-images.githubusercontent.com/1778167/138151437-73adef9b-a1f8-4042-933d-6979ad8bedc2.jpg

https://user-images.githubusercontent.com/1778167/138151450-44def812-1109-4c83-87d0-d1c03b7fbe5f.jpg

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
