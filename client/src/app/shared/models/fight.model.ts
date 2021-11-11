export class Fight {
    constructor(public id: number,
                public fighterId1: number, public fighterName1: string,
                public fighterId2: number, public fighterName2: string,
                public winnerId: number, public winnerName: string,
                public fightTime: Date, public fightTimeString: string,
                public tournamentId: number, public tournamentName: string) { }
}
