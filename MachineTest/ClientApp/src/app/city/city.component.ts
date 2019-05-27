import { Component, OnInit,Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { City } from '../model/city';


@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  public cities: City[];
  _baseUrl : string = '';
 
  description: string;
  name: string;
  id : number;


  constructor(public dialog: MatDialog,@Inject('BASE_URL') baseUrl: string,public http: HttpClient) {
    this._baseUrl=baseUrl;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CityModal, {
      width: '350px',
      data: {id: this.id, name: this.name, description: this.description}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(result.id==0){
        this.saveCity(result);
      }else{
        this.updateCity(result);
      }
    });
  }

  ngOnInit() {
    this.getAllCities();
  }

  addCity(){
    this.id=0;
    this.name='';
    this.description = '';
    this.openDialog();
  }

  getAllCities(){
    this.http.get<City[]>(this._baseUrl + 'api/City/GetAll').subscribe(result => {
      this.cities = result;
    }, error => console.error(error));
  }

  deleteCity(cityId){
    var isConfirm = confirm("Do you want to delete the city ? ");
    if(isConfirm){
      this.http.delete(this._baseUrl + 'api/City/Delete/'+ cityId).subscribe(result => {
        this.getAllCities();
      }, error => console.error(error));
    }
  }

  saveCity(data){
    this.http.post<City>(this._baseUrl + 'api/City/Save', data).subscribe(result => {
      this.getAllCities();
    }, error => console.error(error));
  }

  updateCity(data){
    this.http.put<City>(this._baseUrl + 'api/City/Update', data).subscribe(result => {
      this.getAllCities();
    }, error => console.error(error));
  }

  getCityById(cityId){
    this.http.get<City>(this._baseUrl + 'api/City/GetById/'+ cityId).subscribe(result => {
      this.id=result.id;
      this.name =result.name;
      this.description = result.description;
      this.openDialog()
    }, error => console.error(error));
  }

  
}


@Component({
  selector: 'city-modal',
  templateUrl: 'city-modal.html',
})
export class CityModal {

  constructor(
    public dialogRef: MatDialogRef<CityModal>,
    @Inject(MAT_DIALOG_DATA) public data: City) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  name = new FormControl('', [Validators.required, Validators.email]);

  getErrorMessage() {
    return this.name.hasError('required') ? 'You must enter a value' : '';
  }

}
