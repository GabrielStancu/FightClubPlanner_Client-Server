import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Tournament } from '../shared/models/tournament.model';
import { Observable } from 'rxjs';
import { DetailedTournament } from '../shared/models/detailed-tournament.model';
import { Fighter } from '../shared/models/fighter.model';
import { Invite } from '../shared/models/invite.model';
import { Fight } from '../shared/models/fight.model';

@Injectable({
    providedIn: 'root'
})
export class ManagerService {
    readonly APIUrl = 'http://localhost:5000/api/manager';

    constructor(private httpClient: HttpClient) {}

    getTournamentsForManager(id: number): Observable<Tournament[]>{
        return this.httpClient.get<Tournament[]>(this.APIUrl + '/tournaments/' + id.toString());
    }

    createTournament(tournament: Tournament): Observable<boolean>{
        return this.httpClient.post<boolean>(this.APIUrl + '/tournaments/', tournament);
    }

    getTournamentInfo(id: number): Observable<DetailedTournament>{
        return this.httpClient.get<DetailedTournament>(this.APIUrl + '/tournamentdetails/' + id.toString());
    }

    getInvitableFighters(tournamentId: number): Observable<Fighter[]>{
        return this.httpClient.get<Fighter[]>(this.APIUrl + '/invitableFighters/' + tournamentId.toString());
    }

    sendInvite(invite: Invite): Observable<boolean>{
        return this.httpClient.post<boolean>(this.APIUrl + '/invites', invite);
    }

    pickWinner(fight: Fight): Observable<boolean>{
        return this.httpClient.put<boolean>(this.APIUrl, fight);
    }

    generateWeeklyFights(tournamentId: number): Observable<boolean>{
        return this.httpClient.get<boolean>(this.APIUrl + '/weeklyfights/' + tournamentId.toString());
    }

    generateMonthlyFights(tournamentId: number): Observable<boolean>{
        return this.httpClient.get<boolean>(this.APIUrl + '/monthlyfights/' + tournamentId.toString());
    }

    rescheduleFights(tournamentId: number): Observable<boolean>{
        return this.httpClient.get<boolean>(this.APIUrl + '/reschedule/' + tournamentId.toString());
    }
}
