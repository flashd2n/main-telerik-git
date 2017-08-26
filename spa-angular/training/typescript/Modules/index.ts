import { IStringValidator, ZipCodeValidator as ZCV } from './validators';

var validator = new ZCV();
console.log(validator.isAcceptable("1000"));