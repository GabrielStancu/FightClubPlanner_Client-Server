import { Tournament } from './tournament.model';

export class Manager {
    constructor(public id: number, public fullName: string,
                public username: string, public tournaments: Tournament[]){ }
}
