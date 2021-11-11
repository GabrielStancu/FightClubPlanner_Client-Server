import { CovidTest } from './covid-test.model';
import { Fight } from './fight.model';
import { Invite } from './invite.model';
import { Tournament } from './tournament.model';

export class DetailedFighter {
    constructor(public fightHistory: Fight[], public testHistory: CovidTest[],
                public tournaments: Tournament[], public invites: Invite[],
                public age: number, public weight: number,
                public height: number, public isEligible: boolean){ }
}
