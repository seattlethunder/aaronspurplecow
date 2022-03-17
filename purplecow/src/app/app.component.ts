import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public images?: Image[];

  constructor(http: HttpClient) {


    http.get<Image[]>('/image').subscribe(result => {
      this.images = result;
    }, error => console.error(error));

  }

  title = 'purplecow';
}

interface Image {
  name: string;
  id: number;
}
