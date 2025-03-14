import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../services/weather.service';
import { WeatherForecast } from '../../models/weather-forecast.model';

@Component({
  selector: 'app-weather-list',
  templateUrl: './weather-list.component.html',
  styleUrls: ['./weather-list.component.scss']
})
export class WeatherListComponent implements OnInit {
  forecasts: WeatherForecast[] = [];
  loading = true;
  error = false;

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.getWeatherForecasts();
  }

  getWeatherForecasts(): void {
    this.loading = true;
    this.error = false;
    
    this.weatherService.getWeatherForecasts()
      .subscribe({
        next: (data) => {
          this.forecasts = data;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error fetching weather forecasts', err);
          this.error = true;
          this.loading = false;
        }
      });
  }

  formatDate(dateString: string): string {
    const date = new Date(dateString);
    return date.toLocaleDateString('en-US', { 
      weekday: 'long', 
      year: 'numeric', 
      month: 'long', 
      day: 'numeric' 
    });
  }
}