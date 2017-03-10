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
        },
        validateUpdateExercisePassedObject: function (input) {
            if (typeof input !== 'object') {
                throw new Error('The passed parameter is not an object');
            }
            if (!input.hasOwnProperty('name')) {
                throw new Error('The passed object does not have property name');
            }
            this.validateStringLength(input.name, 1, 30);
            this.validateStringSymbolsOnlyLettersAndWhiteSpaces(input.name);
            if (input.hasOwnProperty('trainingPartner')) {
                throw new Error('Cannot change trainingPartner property');
            }
            if (input.hasOwnProperty('description')) {
                this.validateStringLength(input.description, 0, 159);
            }
            if (input.hasOwnProperty('rest')) {
                this.validateIntegerSize(input.rest, 1, 119);
            }
            if (input.hasOwnProperty('personalRating')) {
                this.validateIntegerSize(input.personalRating, 1, 10);
            }
            if (input.hasOwnProperty('improvementStats')) {
                this.validateImprovementStats(input.improvementStats);
            }
        },
        validateUpdateGymPassedObject: function (input, currentBestWeight) {
            this.validateUpdateExercisePassedObject(input);
            if (input.hasOwnProperty('numberOfSets')) {
                this.validateNumberRange(input.numberOfSets, 0, 9);
            }
            if (input.hasOwnProperty('primaryMuscleGroup')) {
                this.validateStringLength(input.primaryMuscleGroup, 1, 50);
                this.validateStringSymbolsOnlyLettersAndWhiteSpaces(input.primaryMuscleGroup);
            }
            if (input.hasOwnProperty('secondaryMuscleGroup')) {
                this.validateStringLength(input.secondaryMuscleGroup, 1, 75);
                this.validateStringSymbolsOnlyLettersAndWhiteSpaces(input.secondaryMuscleGroup);
            }
            if (input.hasOwnProperty('bestWeight')) {
                this.validateIntegerSize(input.bestWeight, 0, 100);
                if (input.bestWeight < currentBestWeight) {
                    throw new Error('Train harder, you weakling!');
                }
            }
        },
        validateUpdatePoleDancingPassedObject: function (input) {
            this.validateUpdateExercisePassedObject(input);
            if (input.hasOwnProperty('difficulty')) {
                this.validateDifficulty(input.difficulty);

            }
            if (input.hasOwnProperty('type')) {
                this.validateType(input.type);

            }
        },
        validateDay: function (input) {
            this.validateString(input);
            if (input !== 'monday' && input !== 'tuesday' && input !== 'wednesday' && input !== 'thursday' && input !== 'friday' && input !== 'saturday' && input !== 'sunday') {
                throw new Error('Invalid day of the week');
            }
        },
        validateExerciseInstance: function (input) {
            if (!(input instanceof Exercise)) {
                throw new Error('Not a valid Exercise instance');
            }
        },
        validateQuery: function (input) {
            if (typeof input !== 'object') {
                throw new Error('The passed query is not an object');
            }

            if (input.hasOwnProperty('primaryMuscleGroup') && input.hasOwnProperty('difficulty')) {
                throw new Error('Invalid combination of properties');
            }
        },
        validateListProperty: function (input) {
            if (typeof input !== 'string') {
                throw new Error('Property must be a string');
            }
            if (input === 'name') {
                throw new Error('Property cannot be name');
            }
            if (input !== 'name' && input !== 'description' && input !== 'rest' && input !== 'trainingPartner' && input !== 'personalRating' && input !== 'caloriesBurn' && input !== 'performanceGain' && input !== 'numberOfSets' && input !== 'primaryMuscleGroup' && input !== 'secondaryMuscleGroup' && input !== 'bestWeight' && input !== 'difficulty' && input !== 'type') {
                throw new Error('This is not a valid gym or pole dance property');
            }

        },
        validateGetProgramQueryDay: function (input) {

            if (typeof input !== 'string') {
                throw new Error('The passed query is neither a string nor an object');
            }

            if (typeof input === 'string') {
                if (input !== 'monday' && input !== 'tuesday' && input !== 'wednesday' && input !== 'thursday' && input !== 'friday' && input !== 'saturday' && input !== 'sunday') {
                    throw new Error('invalid day of the week');
                }
            }

        },
        validatePropertyCombination: function (input) {
            if (input.hasOwnProperty('difficulty') || input.hasOwnProperty('type')) {
                if (input.hasOwnProperty('numberOfSets') || input.hasOwnProperty('primaryMuscleGroup') || input.hasOwnProperty('secondaryMuscleGroup') || input.hasOwnProperty('bestWeight')) {
                    throw new Error('Invalid combination of properties');
                }
            }
        }
    };

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
            VALIDATION.validateStringLength(value, 1, 159);
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
            VALIDATION.validateUpdateExercisePassedObject(option);

            let properties = Object.keys(option);

            properties.forEach(x => this[x] = option[x]);

            return this;
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
            VALIDATION.validateUpdateGymPassedObject(option, this.bestWeight);
            super.update(option);
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
            VALIDATION.validateUpdatePoleDancingPassedObject(option);
            super.update(option);
        }
    }


    class TrainingPlanner {
        constructor(personalData) {
            this.personalData = personalData;
            this._exerciseDatabase = [];
            this._schedule = [{ day: 'monday', dailyExercises: [], overallRating: 0 }, { day: 'tuesday', dailyExercises: [], overallRating: 0 }, { day: 'wednesday', dailyExercises: [], overallRating: 0 }, { day: 'thursday', dailyExercises: [], overallRating: 0 }, { day: 'friday', dailyExercises: [], overallRating: 0 }, { day: 'saturday', dailyExercises: [], overallRating: 0 }, { day: 'sunday', dailyExercises: [], overallRating: 0 }];
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
            if (exercise.hasOwnProperty('difficulty') || exercise.hasOwnProperty('_difficulty')) {
                return new PoleDancing(exercise.name, exercise.description, exercise.rest, exercise.trainingPartner, exercise.personalRating, exercise.improvementStats, exercise.difficulty, exercise.type);
            }
            return new GymExercise(exercise.name, exercise.description, exercise.rest, exercise.trainingPartner, exercise.personalRating, exercise.improvementStats, exercise.numberOfSets, exercise.primaryMuscleGroup, exercise.secondaryMuscleGroup, exercise.bestWeight);
        }

        addExerciseToDatabase(exercises) {


            if (Array.isArray(exercises)) {

                for (let i = 0; i < exercises.length; i++) {

                    let exerciseToAdd;
                    try {
                        exerciseToAdd = this.createExercise(exercises[i]);
                    } catch (error) {
                        continue;
                    }
                    if (this.exerciseDatabase.some(x => x.name === exerciseToAdd.name)) {
                        continue;
                    }
                    this.exerciseDatabase.push(exerciseToAdd);
                }

                return this;
            }

            let exerciseToAdd;
            try {
                exerciseToAdd = this.createExercise(exercises);
            } catch (error) {
                throw new Error('The passed parameter is not an object');
            }

            if (this.exerciseDatabase.some(x => x.name === exerciseToAdd.name)) {
                throw new Error('This exercise is already added');
            }

            this.exerciseDatabase.push(exerciseToAdd);

            return this;
        }

        addExercisetoSchedule(day, exercises) {
            VALIDATION.validateDay(day);

            if (Array.isArray(exercises)) {

                let exerciseToAdd;
                let self = this;
                let tempArray = [];

                exercises.forEach(function (exercise) {
                    exerciseToAdd = self.createExercise(exercise);
                    tempArray.push(exerciseToAdd);
                });

                let indexToAdd = this.schedule.findIndex(x => x.day === day);

                tempArray.forEach(function (x) {
                    self.schedule[indexToAdd].dailyExercises.push(x);
                    self.schedule[indexToAdd].overallRating += x.personalRating;
                });

                return this;
            }

            let exerciseToAdd;

            try {
                exerciseToAdd = this.createExercise(exercises);
            } catch (error) {
                throw new Error('This is not a valid exercise or exercise-like object!');
            }

            let indexToAdd = this.schedule.findIndex(x => x.day === day);
            this.schedule[indexToAdd].dailyExercises.push(exerciseToAdd);
            this.schedule[indexToAdd].overallRating += exerciseToAdd.personalRating;
            return this;
        }

        updateExercise(exercise) {

            VALIDATION.validateExerciseInstance(exercise);

            let indexToFind = this.exerciseDatabase.findIndex(x => x.name === exercise.name);

            if (indexToFind < 0) {
                this.exerciseDatabase.push(exercise);
                return this;
            }

            this.exerciseDatabase[indexToFind] = exercise;
            return this;

        }

        getAllExercises() {
            return this.exerciseDatabase.slice().sort(function (x, y) {
                if (x.personalRating === y.personalRating) {
                    return y.improvementStats.performanceGain - x.improvementStats.performanceGain;
                }
                return y.personalRating - x.personalRating;
            });
        }

        searchExercises(query) {
            VALIDATION.validateQuery(query);

            return this.exerciseDatabase.filter(function (x) {
                return (!query.hasOwnProperty('trainingPartner') || query.trainingPartner === x.trainingPartner) &&
                    (!query.hasOwnProperty('rest') || query.rest === x.rest) &&
                    (!query.hasOwnProperty('caloriesBurn') || query.caloriesBurn === x.improvementStats.caloriesBurn) &&
                    (!query.hasOwnProperty('primaryMuscleGroup') || query.primaryMuscleGroup === x.primaryMuscleGroup) &&
                    (!query.hasOwnProperty('difficulty') || query.difficulty === x.difficulty);
            });
        }

        listExercises(count, property) {
            VALIDATION.validateListProperty(property);

            let countToReturn = count || 10;

            if (property === 'caloriesBurn' || property === 'performanceGain') {

                return this.exerciseDatabase.slice().sort(function (x, y) {
                    return x.improvementStats[property] - y.improvementStats[property];
                }).slice(0, countToReturn);
            }

            if (!this.exerciseDatabase.some(x => x.hasOwnProperty(`_${property}`)) && (property !== 'caloriesBurn' && property !== 'performanceGain')) {
                return [];
            }


            if (property === 'name' || property === 'description' || property === 'trainingPartner' || property === 'primaryMuscleGroup' || property === 'secondaryMuscleGroup' || property === 'difficulty' || property === 'type') {
                return this.exerciseDatabase.slice().sort((x, y) => x[property] > y[property]).slice(0, countToReturn);
            }

            return this.exerciseDatabase.slice().sort(function (x, y) {
                return x[property] - y[property];
            }).slice(0, countToReturn);
        }

        getProgram(query) {

            if (typeof query !== 'object' && typeof query !== 'string') {
                throw new Error('The query is neither a string not an object');
            }
            if (typeof query === 'string') {
                VALIDATION.validateGetProgramQueryDay(query);

                let indexToReturn = this.schedule.findIndex(x => x.day === query);

                return this.schedule[indexToReturn].dailyExercises;
            }

            let queryProperties = Object.keys(query);
            queryProperties.forEach(x => VALIDATION.validateListProperty(x));
            VALIDATION.validatePropertyCombination(query);

            let result = [];

            this.schedule.forEach(function (day) {

                let successDay = day.dailyExercises.some(function (exercise) {

                    return queryProperties.every(function (property) {

                        if (property === 'caloriesBurn' || property === 'performanceGain') {
                            return query[property] === exercise.improvementStats[property];
                        }

                        return query[property] === exercise[property];
                    });
                });

                if (successDay) {
                    result.push(day.day);
                }
            });

            return result.filter((day, index, array) => day !== array[index - 1]);
        }

        getWeeklySchedule() {

            return this.schedule.slice().sort((x, y) => x.overallRating - y.overallRating);

        }

        train(day) {
            VALIDATION.validateDay(day);

            let dayIndex = this.schedule.findIndex(x => x.day === day);
            if (this.schedule[dayIndex].dailyExercises.length === 0) {
                return this.personalData;
            }

            let totalCalories = this.schedule[dayIndex].dailyExercises.reduce((x, y) => x + y.improvementStats.caloriesBurn, 0);
            let totalPerformanceGain = this.schedule[dayIndex].dailyExercises.reduce((x, y) => x + y.improvementStats.performanceGain, 0);

            this.personalData.weight -= (this.personalData.weight / totalCalories);
            this.personalData.fatPercentage -= (this.personalData.fatPercentage / totalCalories);
            this.personalData.endurance += totalPerformanceGain / 100;
            this.personalData.strength += totalPerformanceGain / 100;

            return this.personalData;

        }


        trainWeeks(count) {
            VALIDATION.validateIntegerSize(count, 1);

            for (let i = 0; i < count; i++) {
                this.train('monday');
                this.train('tuesday');
                this.train('wednesday');
                this.train('thursday');
                this.train('friday');
                this.train('saturday');
                this.train('sunday');
            }
            return this.personalData;
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