import { FighterComponent } from './fighter-component.model';


export abstract class FighterDecorator extends FighterComponent{
    constructor(public fighterComponent: FighterComponent){
        super();
    }

    stringToColor(): string{
        if (this.fighterComponent !== null){
            return this.fighterComponent.stringToColor();
        }

        return null;
    }
}
