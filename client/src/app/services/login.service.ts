import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import { LoginResult } from '../shared/models/login-result.model';
import { LoginUser } from '../shared/models/login-user.model';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    readonly APIUrl = 'http://localhost:5000/api/login';

    constructor(private http: HttpClient) {}

    loginUser(username: string, password: string): Observable<LoginResult> {
        const loginUser = new LoginUser(username, password);

        return this.http.post<LoginResult>(this.APIUrl, loginUser);
    }
}
