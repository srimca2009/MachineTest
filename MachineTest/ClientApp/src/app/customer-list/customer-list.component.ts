import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, Validators,FormGroupDirective, NgForm,  FormGroup} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../model/customer';


@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  _baseUrl : string ='';
  public customers: Customer[];

  constructor(@Inject('BASE_URL') baseUrl: string,public http: HttpClient) {
    this._baseUrl = baseUrl;

   }

  ngOnInit() {
    this.getCustomersList();
  }

  getCustomersList(){
    this.http.get<Customer[]>(this._baseUrl + 'api/Customer/GetAll').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }

  deleteCustomer(custId){
    var isConfirm = confirm("Do you want to delete the city ? ");
    if(isConfirm){
      this.http.delete(this._baseUrl + 'api/Customer/Delete/'+ custId).subscribe(result => {
        this.getCustomersList();
      }, error => console.error(error));
    }
  }
}
