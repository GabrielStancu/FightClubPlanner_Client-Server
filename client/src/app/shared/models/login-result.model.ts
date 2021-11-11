import { UserType } from '../helpers/user-type.enum';

export class LoginResult {
    constructor(public loginSuccess: boolean, public userId: boolean,
                public userType: UserType) { }
}
