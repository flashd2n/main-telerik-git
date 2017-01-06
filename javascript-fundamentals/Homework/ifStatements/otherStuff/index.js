function solve(arg) {

    var num = +arg[0],
        hundred = "hundred",
        ones = ["", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
        tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"],
        teens = ["ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
        result = "";
    if (num === 0) {
        result = "zero";
    } else if (num > 0 && num < 10) {
        result = ones[num];
    } else if (num > 9 && num < 20) {
        var convert = num % 10;
        result = teens[convert];
    } else if (num > 19 && num < 99) {
        var tensIndex = Math.floor(num / 10);
        var onesIndex = num % 10;
        result = tens[tensIndex] + " " + ones[onesIndex];
    } else if (num > 99) {
        var convertHundreds = Math.floor(num / 100);
        var convertTens = Math.floor((num % 100) / 10);
        var convertOnes = num % 10;
        if (convertTens === 0 && convertOnes === 0) {
            result = ones[convertHundreds] + " " + hundred;
        } else if (convertTens === 0) {
            result = ones[convertHundreds] + " " + hundred + " and " + ones[convertOnes];
        } else if (convertTens === 1) {
            result = ones[convertHundreds] + " " + hundred + " and " + teens[convertOnes];
        } else if (convertTens > 1 && convertOnes === 0) {
            result = ones[convertHundreds] + " " + hundred + " and " + tens[convertTens];
        } else {
            result = ones[convertHundreds] + " " + hundred + " and" + " " + tens[convertTens] + " " + ones[convertOnes];
        }
    }
    console.log(result.charAt(0).toUpperCase() + result.slice(1));
}

let arg = ['211'];

solve(arg);