import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ng-cookie-example';

  constructor() {
  }

  async dostuff() {
    const url = 'https://localhost:44376/WeatherForecast';
    const options: RequestInit = {
      method: 'GET',
      credentials: 'include'
    };
    const response = await fetch(url, options);
    // const body = await response.json();
    // const headers = response.headers;
    // console.log(headers);
  }
}
