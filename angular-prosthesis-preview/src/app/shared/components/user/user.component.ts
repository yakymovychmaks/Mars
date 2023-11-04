import { Component } from '@angular/core';
import {User} from "../../models/user.model";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {


  public userGroup = new FormGroup({
    name: new FormControl(''),
    age: new FormControl(''),
    phoneNumber: new FormControl(''),
    login: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl('')
  })
  public onSubmit(){

    console.log(this.userGroup.getRawValue())

  }
}
