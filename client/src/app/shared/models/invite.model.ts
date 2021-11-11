import { InviteState } from '../helpers/invite-state.enum';

export class Invite {
    constructor(public fighterId: number,
                public dateSent: Date, public inviteState: InviteState,
                public tournamentId: number, public tournamentName?: string,
                public tournamentLocation?: string,
                public dateSentString?: string,
                public inviteStateString?: string, public id?: number) {
    }
}
