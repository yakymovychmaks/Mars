import {UserDto} from "../interfaces/user-dto";

export class User {
  public id: string;
  public name: string;
  public age: number;
  public login: string;
  public password: string;
  public email: string;
  public phoneNumber: string;

  constructor(
      { name, age, login, password, email, phoneNumber } : UserDto
  ) {
    this.id = "undefinded";
    this.name = name;
    this.age = age;
    this.email = email;
    this.login = login;
    this.password = password;
    this.phoneNumber = phoneNumber;
  }
}
