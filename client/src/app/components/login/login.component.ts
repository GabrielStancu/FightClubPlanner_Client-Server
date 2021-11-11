import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { UserType } from 'src/app/shared/helpers/user-type.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  onLogin(): void {
    // tslint:disable-next-line: deprecation
    this.loginService.loginUser(this.username, this.password).subscribe(loginResult => {
      if (loginResult.userType === UserType.Manager) {
        localStorage.setItem('managerId', loginResult.userId.toString());
        this.router.navigate(['manager']);
      } else if (loginResult.userType === UserType.Fighter){
        localStorage.setItem('fighterId', loginResult.userId.toString());
        this.router.navigate(['fighter']);
      } else if (loginResult.userType === UserType.NotRegistered) {
        alert('The provided user does not exist!');
      }
    });
  }
}
