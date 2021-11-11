export class Tournament{
    constructor(public name: string,
                public location: string, public startDate: Date,
                public startDateString?: string, public id?: number,
                public organizerId?: number){
    }
}
