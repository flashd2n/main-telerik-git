'use strict';

function solve() {

    const VALIDATION = {
        validateNonNegativeNumber: function (value) {
            if (typeof value !== 'number' || isNaN(value) || value <= 0) {
                throw new Error('The number is not valid');
            }
        },
        validateNumberRange: function (value, min, max) {
            this.validateNonNegativeNumber(value);
            if (value < min, value > max) {
                throw new Error('The number is outside set boundaries');
            }
        },
        validatePersonalData: function (personalData) {
            if (typeof personalData !== 'object') {
                throw new Error('The passed personal data is not an object');
            }

            if (!personalData.hasOwnProperty('weight')) {
                throw new Error('The passed personal data object does not have property weight');
            }
            this.validateNonNegativeNumber(personalData.weight);

            if (!personalData.hasOwnProperty('fatPercentage')) {
                throw new Error('The passed personal data object does not have property fatPercentage');
            }
            this.validateNumberRange(personalData.fatPercentage, 0, 40);

            if (!personalData.hasOwnProperty('endurance')) {
                throw new Error('The passed personal data object does not have property endurance');
            }
            this.validateNonNegativeNumber(personalData.endurance);
            if (!personalData.hasOwnProperty('strength')) {
                throw new Error('The passed personal data object does not have property strength');
            }
            this.validateNonNegativeNumber(personalData.strength);
        },
        validateExercise: function(exercise){
            if(typeof exercise !== 'object'){
                throw new Error('This is not an object');
            }
        }
    }

    class TrainingPlanner {
        constructor(personalData) {
            this.personalData = personalData;
            this._exerciseDatabase = [];
            this._schedule = [{day: 'monday', dailyExercises: []}, {day: 'tuesday', dailyExercises: []}, {day: 'wednesday', dailyExercises: []}, {day: 'thursday', dailyExercises: []}, {day: 'friday', dailyExercises: []}, {day: 'saturday', dailyExercises: []}, {day: 'sunday', dailyExercises: []}];
        }

        get personalData() {
            return this._personalData;
        }

        set personalData(value) {
            VALIDATION.validatePersonalData(value);
            this._personalData = value;
        }

        get exerciseDatabase(){
            return this._exerciseDatabase;
        }
        get schedule(){
            return this._schedule;
        }

        createExercise(exercise){
            VALIDATION.validateExercise(exercise);
        }



    }

    return {
        createTrainingPlanner(personalData) {
            return new TrainingPlanner(personalData);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve;