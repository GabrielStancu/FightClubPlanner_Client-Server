import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CovidTest } from '../shared/models/covid-test.model';
import { DetailedFighter } from '../shared/models/detailed-fighter.model';
import { Invite } from '../shared/models/invite.model';
import { IsolationBubble } from '../shared/models/isolation-bubble';

@Injectable({
    providedIn: 'root'
})
export class FighterService {
    readonly APIUrl = 'http://localhost:5000/api/fighter/';

    constructor(private httpClient: HttpClient) { }

    getFighterDetails(id: number): Observable<DetailedFighter>{
        return this.httpClient.get<DetailedFighter>
            (this.APIUrl + id.toString());
    }

    getIsolationBubbles(): Observable<IsolationBubble[]>{
        return this.httpClient.get<IsolationBubble[]>
            (this.APIUrl + 'isolationBubbles');
    }

    registerTest(test: CovidTest): Observable<CovidTest[]>{
        return this.httpClient.post<CovidTest[]>(this.APIUrl, test);
    }

    answerInvite(invite: Invite): Observable<any>{
        return this.httpClient.put<any>(this.APIUrl, invite);
    }
}
