import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherForecast } from '../models/weather-forecast.model';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  // Using HTTP URL consistently since we've disabled HTTPS redirection in the backend
  private apiUrl = 'http://localhost:5000/api/weatherforecast';

  constructor(private http: HttpClient) { }

  getWeatherForecasts(): Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>(this.apiUrl);
  }
}