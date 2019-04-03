import {Component, Inject, OnInit} from '@angular/core';
import {HttpService} from "../services/httpService/http.service";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public forecasts: WeatherForecast[];

  constructor(private httpService: HttpService) {
  }

  ngOnInit(): void {
    this.httpService.getForecast().subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

export interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
