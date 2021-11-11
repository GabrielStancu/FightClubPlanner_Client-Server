import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignupService } from 'src/app/services/signup.service';
import { SignupResult } from 'src/app/shared/helpers/signup-result.enum';
import { UserType } from 'src/app/shared/helpers/user-type.enum';
import { SignupUser } from 'src/app/shared/models/signup-user.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private signupService: SignupService, private router: Router) { }

  pickerText = 'UserType';
  disabledFighterFields = false;

  userType: UserType;
  username: string;
  password: string;
  repeatedPassword: string;
  firstName: string;
  lastName: string;
  weight: number;
  height: number;
  birthday: Date = new Date();

  signupUser: SignupUser;

  ngOnInit(): void {
  }

  onSignup(): void{
    this.initializeUserInfo();

    // tslint:disable-next-line: deprecation
    this.signupService.loginUser(this.signupUser).subscribe(signupResult => {
      if (signupResult === SignupResult.Registered){
        alert('User succesfully registered!');
        this.router.navigate(['login']);
      } else if (signupResult === SignupResult.UserAlreadyRegistered){
        alert('User already exists!');
        this.username = '';
      } else {
        alert('Bad credentials, please fill all required fields with valid data!');
      }
    });
  }

  onUserTypePick(userType: UserType): void{
    this.userType = userType;

    if (userType === UserType.Fighter){
      this.pickerText = 'Fighter';
      this.disabledFighterFields = false;
    } else {
      this.pickerText = 'Manager';
      this.disabledFighterFields = true;
    }
  }

  initializeUserInfo(): void{
    this.signupUser = new SignupUser(
      this.userType, this.username, this.password, this.repeatedPassword,
      this.firstName, this.lastName, this.height, this.weight, this.birthday
    );
  }
}
