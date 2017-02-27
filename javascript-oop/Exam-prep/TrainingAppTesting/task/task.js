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
        validateExercise: function (exercise) {
            if (typeof exercise !== 'object') {
                throw new Error('This is not an object');
            }
        },
        validateString: function (input) {
            if (typeof input !== 'string') {
                throw new Error('This is not a string!');
            }
        },
        validateStringSymbolsOnlyLettersAndWhiteSpaces: function (input) {
            this.validateString(input);
            if (!(/^[A-Za-z\d\s]+$/.test(input))) {
                throw new Error('The string contains invalid characters');
            }
        },
        validateStringLength: function (input, min, max) {
            this.validateString(input);
            if (input.length < min || input.length > max) {
                throw new Error('The string is not wihtin allowed length');
            }
        },
        validateInteger: function (input) {
            if (typeof input !== 'number' || isNaN(input)) {
                throw new Error('This is not a number');
            }
        },
        validateIntegerSize: function (input, min, max) {
            this.validateInteger(input);
            if (input < min || input > max) {
                throw new Error('The number is not within the set limits');
            }
        },
        validateImprovementStats: function (input) {
            if (typeof input !== 'object') {
                throw new Error('This is not an object');
            }
            if (!input.hasOwnProperty('caloriesBurn') || !input.hasOwnProperty('performanceGain')) {
                throw new Error('The object does not have the correct properties');
            }
            this.validateIntegerSize(input.caloriesBurn, 0);
            this.validateIntegerSize(input.performanceGain, 0);
        },
        validateDifficulty: function (input) {
            this.validateString(input);
            if (input !== 'easy' && input !== 'intermediate' && input !== 'advanced' && input !== 'expert' && input !== 'dorylevel') {
                throw new Error('Invalid difficulty');
            }
        },
        validateType: function (input) {
            this.validateString(input);
            if (input !== 'dance' && input !== 'strength') {
                throw new Error('Invalid type');
            }
        }
    }

    class Exercise {
        constructor(name, description, rest, trainingPartner, personalRating, improvementStats) {
            this.name = name;
            this.description = description;
            this.rest = rest;
            this.trainingPartner = trainingPartner;
            this.personalRating = personalRating;
            this.improvementStats = improvementStats;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            VALIDATION.validateStringLength(value, 1, 30);
            VALIDATION.validateStringSymbolsOnlyLettersAndWhiteSpaces(value);
            this._name = value;
        }
        get description() {
            return this._description;
        }
        set description(value) {
            VALIDATION.validateStringLength(value, 0, 159);
            this._description = value;
        }
        get rest() {
            return this._rest;
        }
        set rest(value) {
            VALIDATION.validateIntegerSize(value, 1, 119);
            this._rest = value;
        }
        get trainingPartner() {
            return this._trainingPartner;
        }
        set trainingPartner(value) {
            VALIDATION.validateStringSymbolsOnlyLettersAndWhiteSpaces(value);
            Object.defineProperty(this, '_trainingPartner', {
                value: value,
                writable: false
            });

        }
        get personalRating() {
            return this._personalRating;
        }
        set personalRating(value) {
            VALIDATION.validateIntegerSize(value, 1, 10);
            this._personalRating = value;
        }
        get improvementStats() {
            return this._improvementStats;
        }
        set improvementStats(value) {
            VALIDATION.validateImprovementStats(value);
            this._improvementStats = value;
        }

        update(option) {
            // TODO
        }
    }

    class GymExercise extends Exercise {
        constructor(name, description, rest, trainingPartner, personalRating, improvementStats, numberOfSets, primaryMuscleGroup, secondaryMuscleGroup, bestWeight) {
            super(name, description, rest, trainingPartner, personalRating, improvementStats);
            this.numberOfSets = numberOfSets;
            this.primaryMuscleGroup = primaryMuscleGroup;
            this.secondaryMuscleGroup = secondaryMuscleGroup;
            this.bestWeight = bestWeight;
        }

        get numberOfSets() {
            return this._numberOfSets;
        }
        set numberOfSets(value) {
            VALIDATION.validateNumberRange(value, 0, 9);
            this._numberOfSets = value;
        }
        get primaryMuscleGroup() {
            return this._primaryMuscleGroup;
        }
        set primaryMuscleGroup(value) {
            VALIDATION.validateStringLength(value, 1, 50);
            VALIDATION.validateStringSymbolsOnlyLettersAndWhiteSpaces(value);
            this._primaryMuscleGroup = value;
        }
        get secondaryMuscleGroup() {
            return this._secondaryMuscleGroup;
        }
        set secondaryMuscleGroup(value) {
            VALIDATION.validateStringLength(value, 1, 75);
            VALIDATION.validateStringSymbolsOnlyLettersAndWhiteSpaces(value);
            this._secondaryMuscleGroup = value;
        }
        get bestWeight() {
            return this._bestWeight;
        }
        set bestWeight(value) {
            VALIDATION.validateIntegerSize(value, 0, 100);
            this._bestWeight = value;
        }


        update(option) {
            // TODO EXTEND
        }
    }


    class PoleDancing extends Exercise {
        constructor(name, description, rest, trainingPartner, personalRating, improvementStats, difficulty, type) {
            super(name, description, rest, trainingPartner, personalRating, improvementStats);
            this.difficulty = difficulty;
            this.type = type;
        }

        get difficulty() {
            return this._difficulty;
        }
        set difficulty(value) {
            VALIDATION.validateDifficulty(value);
            this._difficulty = value;
        }
        get type() {
            return this._type;
        }
        set type(value) {
            VALIDATION.validateType(value);
            this._type = value;
        }


        update(option) {
            // TODO EXTEND
        }
    }


    class TrainingPlanner {
        constructor(personalData) {
            this.personalData = personalData;
            this._exerciseDatabase = [];
            this._schedule = [{ day: 'monday', dailyExercises: [] }, { day: 'tuesday', dailyExercises: [] }, { day: 'wednesday', dailyExercises: [] }, { day: 'thursday', dailyExercises: [] }, { day: 'friday', dailyExercises: [] }, { day: 'saturday', dailyExercises: [] }, { day: 'sunday', dailyExercises: [] }];
        }

        get personalData() {
            return this._personalData;
        }

        set personalData(value) {
            VALIDATION.validatePersonalData(value);
            this._personalData = value;
        }

        get exerciseDatabase() {
            return this._exerciseDatabase;
        }
        get schedule() {
            return this._schedule;
        }

        createExercise(exercise) {
            VALIDATION.validateExercise(exercise);
            if (exercise.hasOwnProperty('difficulty')) {
                return new PoleDancing(exercise.name, exercise.description, exercise.rest, exercise.trainingPartner, exercise.personalRating, exercise.improvementStats, exercise.difficulty, exercise.type);
            }
            return new GymExercise(exercise.name, exercise.description, exercise.rest, exercise.trainingPartner, exercise.personalRating, exercise.improvementStats, exercise.numberOfSets, exercise.primaryMuscleGroup, exercise.secondaryMuscleGroup, exercise.bestWeight);
        }

        addExerciseToDatabase(...exercises){

        }

        addExercisetoSchedule(day, ...exercises){

        }

        updateExercise(exercise){

        }

        getAllExercises(){

        }

        searchExercises(obj){

        }

        listExercises(count, property){

        }

        getProgram(query){

        }

        getWeeklySchedule(){

        }

        train(day){

        }

        trainWeeks(count){

        }

    }

    return {
        createTrainingPlanner(personalData) {
            return new TrainingPlanner(personalData);
        }
    };
}

// const result = solve();

// Submit the code above this line in bgcoder.com
module.exports = solve;