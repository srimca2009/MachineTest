import { Component, OnInit, Inject } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Customer } from '../model/customer';
import { City } from '../model/city';

export interface Food {
  value: string;
  viewValue: string;
}


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  public cities: City[];
  _baseUrl : string = '';

  constructor(@Inject('BASE_URL') baseUrl: string,public http: HttpClient, private _router: Router) { }

  ngOnInit() {
    this.getAllCities();
  }


  customerFormControl = new FormControl('', [
    Validators.required
  ]);
  selectFormControl = new FormControl('', Validators.required);

  getAllCities(){
    this.http.get<City[]>(this._baseUrl + 'api/City/GetAll').subscribe(result => {
      this.cities = result;
    }, error => console.error(error));
  }

  saveCustomer(){
    debugger;
    var dd = this.city
    this._router.navigate(['/customerslist']);
  }



}
