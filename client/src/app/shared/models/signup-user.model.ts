import { UserType } from '../helpers/user-type.enum';

export class SignupUser {
    constructor(public userType: UserType, public username: string,
                public password: string, public repeatedPassword: string,
                public firstName: string, public lastName: string,
                public height: number, public weight: number,
                public birthday: Date){ }
}
