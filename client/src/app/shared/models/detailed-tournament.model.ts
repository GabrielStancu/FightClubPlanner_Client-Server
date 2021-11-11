import { Fight } from './fight.model';
import { Fighter } from './fighter.model';

export class DetailedTournament {
    constructor(public id: number, public fighters: Fighter[],
                public fights: Fight[], public startDate: Date) { }
}
