import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { SignupUser } from '../shared/models/signup-user.model';
import { SignupResult } from '../shared/helpers/signup-result.enum';

@Injectable({
    providedIn: 'root'
})
export class SignupService {
    readonly APIUrl = 'http://localhost:5000/api/signup';

    constructor(private http: HttpClient) {}

    loginUser(signupUser: SignupUser): Observable<SignupResult> {
        return this.http.post<SignupResult>(this.APIUrl, signupUser);
    }
}
