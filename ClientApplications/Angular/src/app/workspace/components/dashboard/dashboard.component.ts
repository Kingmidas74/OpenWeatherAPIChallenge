import { Component, OnInit } from '@angular/core';
import { TemperatureService } from '../../services/temperature.service';

declare var ol: any;

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {


  latitude: number = 18.5204;
  longitude: number = 73.8567;

  map: any;

  constructor(private temperatureService:TemperatureService) { }

  ngOnInit(): void {

    var mousePositionControl = new ol.control.MousePosition({
      coordinateFormat: ol.coordinate.createStringXY(4),
      projection: 'EPSG:4326',
      className: 'custom-mouse-position',
      target: document.getElementById('mouse-position'),
      undefinedHTML: '&nbsp;'
    });


    this.map = new ol.Map({
      target: 'map',
      layers: [
        new ol.layer.Tile({
          source: new ol.source.OSM()
        })
      ],
      view: new ol.View({
        center: ol.proj.fromLonLat([73.8567, 18.5204]),
        zoom: 8
      })
    });

    this.map.on('click', args => {
      console.log(args.coordinate);
      var lonlat = ol.proj.transform(args.coordinate, 'EPSG:3857', 'EPSG:4326');
      console.log(lonlat);
      
      var lon = lonlat[0];
      var lat = lonlat[1];
      this.temperatureService.GetData(lon,lat).subscribe(
        data => {
          alert(data.name+'  '+data.main.temp);
        },
        error => {
          alert('error! See console for details');
          console.error(error);
        }
      )
    });  
  }

}
