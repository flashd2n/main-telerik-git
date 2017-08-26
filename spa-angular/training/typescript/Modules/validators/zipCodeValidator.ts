import { IStringValidator } from './istringValidator';

const numberRegexp = /^[0-9]+$/;

export class ZipCodeValidator implements IStringValidator {
    isAcceptable(s: string) {
        return s.length === 5 && numberRegexp.test(s);
    }
}