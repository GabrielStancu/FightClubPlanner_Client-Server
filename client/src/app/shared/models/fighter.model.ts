import { FighterComponent } from '../helpers/fighter-component.model';

export class Fighter extends FighterComponent{
    constructor(public id: number, public fullName: string,
                public username: string, public age: number,
                public weight: number, public height: number,
                public isEligible: boolean){
                    super();
                }

    stringToColor(): string{
        return '';
    }
}
