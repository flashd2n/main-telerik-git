const { expect } = require('chai');
const result = require('../task/task')();
const validTrainingPlannerObject = { weight: 20, fatPercentage: 10, endurance: 30, strength: 40 };
const validExercise = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 } };
const validGym = { name: 'Valid Name Gym', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
const validPoleDance = { name: 'Valid Name Pole Dance', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };


describe('Training Planner Tests', function () {

	describe('Initiation Properties Tests', function () {

		describe('Training Planner Creation Tests', function () {

			it('expect createTrainingPlanner to be a function', function () {

				expect(result.createTrainingPlanner).to.exist;
				expect(result.createTrainingPlanner).to.be.a('function');
				expect(result.createTrainingPlanner).to.have.length(1);
			});

			it('expect createTrainingPlanner with invalid passed parameter to throw', function () {

				expect(() => result.createTrainingPlanner('not valid')).to.throw();

			});

			it('expect createTrainingPlanner with invalid weigth to throw', function () {

				expect(() => result.createTrainingPlanner({ weight: NaN, fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: undefined, fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: null, fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: -1, fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: '2', fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();

			});

			it('expect createTrainingPlanner with invalid fatPercentage to throw', function () {

				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 41, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: undefined, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: NaN, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: null, endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: '23', endurance: 20, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: -1, endurance: 20, strength: 20 })).to.throw();

			});

			it('expect createTrainingPlanner with invalid endurance to throw', function () {

				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: NaN, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: undefined, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: null, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: -1, strength: 20 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: '2', strength: 20 })).to.throw();
			});

			it('expect createTrainingPlanner with invalid strength to throw', function () {

				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: NaN })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: undefined })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: null })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: -1 })).to.throw();
				expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: '2' })).to.throw();
			});

			it('expect new traininPlanner object to have valid properties', function () {

				const myTrainingPlanner = result.createTrainingPlanner({ weight: 20, fatPercentage: 10, endurance: 30, strength: 40 });

				expect(myTrainingPlanner.personalData.weight).to.equal(20);
				expect(myTrainingPlanner.personalData.fatPercentage).to.equal(10);
				expect(myTrainingPlanner.personalData.endurance).to.equal(30);
				expect(myTrainingPlanner.personalData.strength).to.equal(40);
				expect(myTrainingPlanner.exerciseDatabase).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;
				expect(myTrainingPlanner.schedule).to.be.instanceof(Array);
				expect(myTrainingPlanner.schedule).to.have.length(7);

				expect(myTrainingPlanner.schedule[0].day).to.equal('monday');
				expect(myTrainingPlanner.schedule[0].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[1].day).to.equal('tuesday');
				expect(myTrainingPlanner.schedule[1].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[2].day).to.equal('wednesday');
				expect(myTrainingPlanner.schedule[2].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[3].day).to.equal('thursday');
				expect(myTrainingPlanner.schedule[3].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[4].day).to.equal('friday');
				expect(myTrainingPlanner.schedule[4].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[5].day).to.equal('saturday');
				expect(myTrainingPlanner.schedule[5].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;

				expect(myTrainingPlanner.schedule[6].day).to.equal('sunday');
				expect(myTrainingPlanner.schedule[6].dailyExercises).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.be.empty;
			});

			it('expect new traininPlanner object to have createExercise method with 1 parameter', function () {

				const myTrainingPlanner = result.createTrainingPlanner({ weight: 20, fatPercentage: 20, endurance: 20, strength: 20 });

				expect(myTrainingPlanner.createExercise).to.be.a('function');
				expect(myTrainingPlanner.createExercise).to.have.length(1);

			});

		});


		describe('Exercise Creation Tests', function () {
			it('expect createExercise with invalid passed parameter type to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise('object')).to.throw();
				expect(() => myTrainingPlanner.createExercise(true)).to.throw();
				expect(() => myTrainingPlanner.createExercise(undefined)).to.throw();
				expect(() => myTrainingPlanner.createExercise(42)).to.throw();


			});

			it('expect createExercise with invalid properties to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 3, type: 'dance' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', difficulty: 'dorylevel' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', primaryMuscleGroup: 'dorylevel' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 } })).to.throw();

			});

			it('expect createExercise with invalid name to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: undefined, description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: null, description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: '', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'gosho#pencho', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
			});

			it('expect createExercise with invalid description to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: undefined, rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: { description: 'something' }, rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: '', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'qazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcrqazwsxedcr', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
			});

			it('expect createExercise with invalid rest to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: NaN, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 120, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: undefined, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 0, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: '32', trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
			});

			it('expect createExercise with invalid trainingPartner to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: null, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gos%ho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid personalRating to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: -1, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: null, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: NaN, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 11, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
			});

			it('expect createExercise with invalid improvementStats: caloriesBurn to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: NaN, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: undefined, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: null, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: -1, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: '2', performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
			});

			it('expect createExercise with invalid improvementStats: performanceGain to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: NaN }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: undefined }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: null }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: -1 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: '2' }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});
		});

		describe('Gym Exercise Creation Tests', function () {

			it('expect createExercise with invalid numberOfSets to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: NaN, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: undefined, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: '2', primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: -1, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 10, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid primaryMuscleGroup to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'che$st', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: '', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: { chest: 'chest' }, secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: undefined, secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: false, secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid secondaryMuscleGroup to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'che$st', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: undefined, bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: '', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: true, bestWeight: 75 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: NaN, bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid bestWeight to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: -1 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 101 })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: NaN })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: undefined })).to.throw();

			});

			it('expect new GymExercise object to have all valid properties', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const gymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 0 });

				expect(gymExercise.name).to.equal('Valid Name');
				expect(gymExercise.description).to.equal('Valid Description');
				expect(gymExercise.rest).to.equal(60);
				expect(gymExercise.trainingPartner).to.equal('Gosho');
				expect(gymExercise.personalRating).to.equal(5);

				expect(gymExercise.improvementStats).to.exist;
				expect(gymExercise.improvementStats).to.have.property('caloriesBurn', 50);
				expect(gymExercise.improvementStats).to.have.property('performanceGain', 50);

				expect(gymExercise.numberOfSets).to.equal(5);
				expect(gymExercise.primaryMuscleGroup).to.equal('chest');
				expect(gymExercise.secondaryMuscleGroup).to.equal('Triceps');
				expect(gymExercise.bestWeight).to.equal(0);



			});

			it('expect new GymExercise object to throw when trying to change trainingPartner property after initialization', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });

				expect(() => gymExercise.trainingPartner = 'something').to.throw();

			});

		});

		describe('Pole Dance Exercise Creation Tests', function () {

			it('expect createExercise with invalid difficulty to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'pesholevel', type: 'dance' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 42, type: 'dance' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: undefined, type: 'dance' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'easy#', type: 'dance' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: '', type: 'dance' })).to.throw();

			});

			it('expect createExercise with invalid type to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dances' })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: undefined })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: NaN })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: true })).to.throw();
				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'strenght' })).to.throw();

			});

			it('expect new PoleDancing object to have all valid properties', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const poleDancingExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' });

				expect(poleDancingExercise.name).to.equal('Valid Name');
				expect(poleDancingExercise.description).to.equal('Valid Description');
				expect(poleDancingExercise.rest).to.equal(60);
				expect(poleDancingExercise.trainingPartner).to.equal('Gosho');
				expect(poleDancingExercise.personalRating).to.equal(5);

				expect(poleDancingExercise.improvementStats).to.exist;
				expect(poleDancingExercise.improvementStats).to.have.property('caloriesBurn', 50);
				expect(poleDancingExercise.improvementStats).to.have.property('performanceGain', 50);

				expect(poleDancingExercise.difficulty).to.equal('dorylevel');
				expect(poleDancingExercise.type).to.equal('dance');

			});
		});
	});

	describe('Initiation Methods Tests', function () {

		it('expect new gym exercise object ot have all of its methods', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			const gymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });

			expect(gymExercise.update).to.exist;
			expect(gymExercise.update).to.be.a('function');
			expect(gymExercise.update).to.have.length(1);

		});

		it('expect new pole dancing exercise object ot have all of its methods', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
			const poleDancingExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' });

			expect(poleDancingExercise.update).to.exist;
			expect(poleDancingExercise.update).to.be.a('function');
			expect(poleDancingExercise.update).to.have.length(1);

		});

		it('expect new myTrainingPlanner object ot have correct addExerciseToDatabase method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.addExerciseToDatabase).to.exist;
			expect(myTrainingPlanner.addExerciseToDatabase).to.be.a('function');
			expect(myTrainingPlanner.addExerciseToDatabase).to.have.length(1);


		});

		it('expect new myTrainingPlanner object ot have correct addExercisetoSchedule method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.addExercisetoSchedule).to.exist;
			expect(myTrainingPlanner.addExercisetoSchedule).to.be.a('function');
			expect(myTrainingPlanner.addExercisetoSchedule).to.have.length(2); // because when function has a "normal" parameter and a single REST operator as a parameter, length returns 1

		});

		it('expect new myTrainingPlanner object ot have correct updateExercise method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.updateExercise).to.exist;
			expect(myTrainingPlanner.updateExercise).to.be.a('function');
			expect(myTrainingPlanner.updateExercise).to.have.length(1);

		});

		it('expect new myTrainingPlanner object ot have correct getAllExercises method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.getAllExercises).to.exist;
			expect(myTrainingPlanner.getAllExercises).to.be.a('function');
			expect(myTrainingPlanner.getAllExercises).to.have.length(0);

		});

		it('expect new myTrainingPlanner object ot have correct searchExercises method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.searchExercises).to.exist;
			expect(myTrainingPlanner.searchExercises).to.be.a('function');
			expect(myTrainingPlanner.searchExercises).to.have.length(1);

		});

		it('expect new myTrainingPlanner object ot have correct listExercises method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.listExercises).to.exist;
			expect(myTrainingPlanner.listExercises).to.be.a('function');
			expect(myTrainingPlanner.listExercises).to.have.length(2);

		});

		it('expect new myTrainingPlanner object ot have correct getProgram method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.getProgram).to.exist;
			expect(myTrainingPlanner.getProgram).to.be.a('function');
			expect(myTrainingPlanner.getProgram).to.have.length(1);

		});

		it('expect new myTrainingPlanner object ot have correct getWeeklySchedule method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.getWeeklySchedule).to.exist;
			expect(myTrainingPlanner.getWeeklySchedule).to.be.a('function');
			expect(myTrainingPlanner.getWeeklySchedule).to.have.length(0);

		});

		it('expect new myTrainingPlanner object ot have correct train method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.train).to.exist;
			expect(myTrainingPlanner.train).to.be.a('function');
			expect(myTrainingPlanner.train).to.have.length(1);

		});

		it('expect new myTrainingPlanner object ot have correct trainWeeks method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.trainWeeks).to.exist;
			expect(myTrainingPlanner.trainWeeks).to.be.a('function');
			expect(myTrainingPlanner.trainWeeks).to.have.length(1);

		});

	});

	describe('Tests of Correct Method Behaviour', function () {

		describe('Gym Exercise Update Tests', function () {

			it('expect update to throw when the passed parameter is not an object', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);

				expect(() => myGymExercise.update('name')).to.throw();

			});

			it('expect update to throw when no name is provided', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);

				const toUpdate = { description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 80 };

				expect(() => myGymExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when the passed bestWeight is than the current with message', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 20 };

				expect(() => myGymExercise.update(toUpdate)).to.throw('Train harder, you weakling!');


			});

			it('expect update to throw when trying to change the trainingPartner property', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'something', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 80 };

				expect(() => myGymExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 1', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 120, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 80 };

				expect(() => myGymExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 10, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 80 };

				expect(() => myGymExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 3', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 4, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: '', bestWeight: 80 };

				expect(() => myGymExercise.update(toUpdate)).to.throw();

			});

			it('expect update to not throw an error when the passed parameter is valid, but no property needs updating', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: validGym.name, description: validGym.description, rest: validGym.rest };

				myGymExercise.update(toUpdate);

				expect(myGymExercise.name).to.equal('Valid Name Gym');
				expect(myGymExercise.description).to.equal('Valid Description');
				expect(myGymExercise.rest).to.equal(60);
			});

			it('expect update to correctly update a gym exercise when only one property needs updating', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: validGym.name, rest: 90 };

				myGymExercise.update(toUpdate);

				expect(myGymExercise.name).to.equal('Valid Name Gym');
				expect(myGymExercise.rest).to.equal(90);

			});

			it('expect update to correctly update a gym exercise when multiple properties needs updating', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myGymExercise = myTrainingPlanner.createExercise(validGym);
				const toUpdate = { name: validGym.name, rest: 20, personalRating: 2 };

				myGymExercise.update(toUpdate);

				expect(myGymExercise.name).to.equal('Valid Name Gym');
				expect(myGymExercise.rest).to.equal(20);
				expect(myGymExercise.personalRating).to.equal(2);
			});

		});

		describe('Pole Dancing Exercise Update Tests', function () {

			it('expect update to throw when the passed parameter is not an object', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };

				expect(() => myPoleDanceExercise.update(true)).to.throw();

			});

			it('expect update to throw when no name is provided', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };

				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dancee' };

				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'notdorylevel', type: 'dance' };

				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 3', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 11, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };

				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 4', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: '', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };

				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to not throw an error when the passed parameter is valid, but no property needs updating', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);
				const toUpdate = { name: validPoleDance.name, description: validPoleDance.description, difficulty: validPoleDance.difficulty };
				myPoleDanceExercise.update(toUpdate);

				expect(myPoleDanceExercise.name).to.equal('Valid Name Pole Dance');
				expect(myPoleDanceExercise.description).to.equal('Valid Description');
				expect(myPoleDanceExercise.difficulty).to.equal('dorylevel');
			});

			it('expect update to correctly update a gym exercise when only one property needs updating', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);
				const toUpdate = { name: validPoleDance.name, description: 'much better description' };
				myPoleDanceExercise.update(toUpdate);

				expect(myPoleDanceExercise.name).to.equal('Valid Name Pole Dance');
				expect(myPoleDanceExercise.description).to.equal('much better description');
			});

			it('expect update to correctly update a gym exercise when multiple properties needs updating', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);
				const toUpdate = { name: validPoleDance.name, difficulty: 'easy', type: 'strength' };
				myPoleDanceExercise.update(toUpdate);

				expect(myPoleDanceExercise.name).to.equal('Valid Name Pole Dance');
				expect(myPoleDanceExercise.difficulty).to.equal('easy');
				expect(myPoleDanceExercise.type).to.equal('strength');
			});

		});

		describe('addExerciseToDatabase() Tests', function () {

			it('expect addExerciseToDatabase to throw when the passed parameter is not an object', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.addExerciseToDatabase(true)).to.throw();

			});

			it('expect addExerciseToDatabase to throw when the passed parameter is not an valid object', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.addExerciseToDatabase({ name: 'something', description: 'very cool' })).to.throw();
			});

			it('expect addExerciseToDatabase to throw when there is already an exercise with the same name in the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExerciseToDatabase(gymExercise);

				expect(() => myTrainingPlanner.addExerciseToDatabase(gymExercise)).to.throw();

			});

			it('expect addExerciseToDatabase to successfully add the exercise to the database', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase(gymExercise);

				expect(myTrainingPlanner.exerciseDatabase).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.have.length(1);
				expect(myTrainingPlanner.exerciseDatabase[0].name).to.equal(gymExercise.name);

			});

			it('expect addExerciseToDatabase to successfully add all exercises to the database when there is one invalid and one valid exercise passed', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, { name: 'lalala', description: 'uuuhaaaaaa' }]);

				expect(myTrainingPlanner.exerciseDatabase).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.have.length(1);
				expect(myTrainingPlanner.exerciseDatabase[0].name).to.equal(gymExercise.name);
			});

			it('expect addExerciseToDatabase to successfully add all exercises to the database when there are two valid exercises passed', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, myPoleDanceExercise]);

				expect(myTrainingPlanner.exerciseDatabase).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.have.length(2);
				expect(myTrainingPlanner.exerciseDatabase[0].name).to.equal(gymExercise.name);
				expect(myTrainingPlanner.exerciseDatabase[1].name).to.equal(myPoleDanceExercise.name);
			});

			it('expect addExerciseToDatabase to successfully add all exercises to the database when there are two valid exercises, but one of them is already in the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase(gymExercise);
				myTrainingPlanner.addExerciseToDatabase([gymExercise, myPoleDanceExercise]);

				expect(myTrainingPlanner.exerciseDatabase).to.be.instanceof(Array);
				expect(myTrainingPlanner.exerciseDatabase).to.have.length(2);
				expect(myTrainingPlanner.exerciseDatabase[0].name).to.equal(gymExercise.name);
				expect(myTrainingPlanner.exerciseDatabase[1].name).to.equal(myPoleDanceExercise.name);

			});
		});

		describe('addExercisetoSchedule() Tests', function () {

			it('expect addExercisetoSchedule to throw when the passed day is not valid', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				expect(() => myTrainingPlanner.addExercisetoSchedule('blaaa', gymExercise)).to.throw();

			});

			it('expect addExercisetoSchedule to throw when the passed exercise is not valid', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.addExercisetoSchedule('monday', { name: 'some name', description: 'uuuhaa' })).to.throw();
			});

			it('expect addExercisetoSchedule to throw when multiple exercises are passed and one of them is not valid', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				expect(() => myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, { name: 'some name', description: 'uuuhaa' }])).to.throw();

			});

			it('expect addExercisetoSchedule to add the correct exercise to the correct day', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise);

				expect(myTrainingPlanner.schedule).to.be.instanceof(Array);
				expect(myTrainingPlanner.schedule[0].dailyExercises).to.have.length(1);
				expect(myTrainingPlanner.schedule[0].dailyExercises[0].name).to.be.equal(gymExercise.name)

			});

			it('expect addExercisetoSchedule to add all exercise to the correct day when all passed exercises are valid', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, poleDanceExercise]);

				expect(myTrainingPlanner.schedule).to.be.instanceof(Array);
				expect(myTrainingPlanner.schedule[0].dailyExercises).to.have.length(2);
				expect(myTrainingPlanner.schedule[0].dailyExercises[0].name).to.be.equal(gymExercise.name)
				expect(myTrainingPlanner.schedule[0].dailyExercises[1].name).to.be.equal(poleDanceExercise.name)
			});


		});

		describe('updateExercise() Tests', function () {

			it('expect updateExercise to throw when passed parameter is not an object', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.updateExercise(true)).to.throw();

			});

			it('expect updateExercise to throw when passed parameter is not an instance of gym', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.updateExercise({ name: 'Valid Name Gym', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect updateExercise to throw when passed parameter is not an instance of pole dance', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.updateExercise({ name: 'Valid Name Pole Dance', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' })).to.throw();

			});

			it('expect updateExercise to successfully update a pre-existing exercise from the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise]);

				const newGymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name Gym', description: 'Valid Description', rest: 20, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });

				myTrainingPlanner.updateExercise(newGymExercise);

				expect(myTrainingPlanner.exerciseDatabase[0].name).to.equal('Valid Name Gym');
				expect(myTrainingPlanner.exerciseDatabase[0].rest).to.equal(20);

			});

			it('expect updateExercise to successfully add a non-existing exercise from the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise]);

				const newGymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name Gym Two', description: 'Valid Description', rest: 20, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });

				myTrainingPlanner.updateExercise(newGymExercise);

				expect(myTrainingPlanner.exerciseDatabase).to.have.length(3);
				expect(myTrainingPlanner.exerciseDatabase[2].name).to.equal('Valid Name Gym Two');
				expect(myTrainingPlanner.exerciseDatabase[2].rest).to.equal(20);
			});

			it('expect updateExercise to provide chaining', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise]);

				const newGymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name Gym', description: 'Valid Description', rest: 20, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });


				expect(myTrainingPlanner.updateExercise(newGymExercise)).to.equal(myTrainingPlanner);

			});

		});

		describe('getAllExercises() Tests', function () {

			it('expect getAllExercises to return an empty array when there are no exercise in the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(myTrainingPlanner.getAllExercises()).to.be.instanceof(Array);
				expect(myTrainingPlanner.getAllExercises()).to.have.length(0);

			});

			it('expect getAllExercises to return an array with one correct element when there is a single exercise in the database', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				let myGymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExerciseToDatabase(myGymExercise);

				let product = myTrainingPlanner.getAllExercises();

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(1);
				expect(product[0].name).to.equal('Valid Name Gym');

			});

			it('expect getAllExercises to return an array with correct length and correct order of exercises when there are exercises in the database', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				let myGymExercise = myTrainingPlanner.createExercise(validGym);
				let myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);
				let newPoleDanceExercise = myTrainingPlanner.createExercise({ name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 9, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' });

				myTrainingPlanner.addExerciseToDatabase([myGymExercise, myPoleDanceExercise, newPoleDanceExercise]);

				let product = myTrainingPlanner.getAllExercises();

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(3);
				expect(product[0].name).to.equal('Valid Name Pole Dance New');
				expect(product[1].name).to.equal('Valid Name Gym');
				expect(product[2].name).to.equal('Valid Name Pole Dance');

			});

		});

		describe('searchExercises() Tests', function () {

			it('expect searchExercises to throw when the passed parameter is not an object', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.searchExercises(undefined)).to.throw();

			});

			it('expect searchExercises to throw when the passed object has an invalid combination of properties', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const searchQuery = { primaryMuscleGroup: 'chest', difficulty: 'easy' };

				expect(() => myTrainingPlanner.searchExercises(searchQuery)).to.throw();

			});

			it('expect searchExercises to return all exercises when the passed object is empty', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);
				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise]);
				const searchQuery = {};

				const product = myTrainingPlanner.searchExercises(searchQuery);

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(2);
				expect(product[0].name).to.equal(validGym.name);
				expect(product[1].name).to.equal(validPoleDance.name);

			});

			it('expect searchExercises to return the correct exercises when the passed object is valid and not empty', function () {


				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 60, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceThree = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 60, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceThree);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				const searchQuery = { trainingPartner: 'dory', caloriesBurn: 60 };

				const product = myTrainingPlanner.searchExercises(searchQuery);
				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(2);
				expect(product[0].name).to.equal('Valid Name Gym New');
				expect(product[1].name).to.equal('Valid Name Pole Dance New');

			});

			it('expect searchExercises to return the correct exercises when the passed object is valid and not empty 2', function () {

				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceThree = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceThree);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				const searchQuery = { rest: 10, caloriesBurn: 60, trainingPartner: 'dory', difficulty: 'easy' };

				const product = myTrainingPlanner.searchExercises(searchQuery);
				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(1);
				expect(product[0].name).to.equal('Valid Name Pole Dance New');

			});

			it('expect searchExercises to return empty array when no exercises match the passed query', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise]);
				const searchQuery = { rest: 10, caloriesBurn: 50, trainingPartner: 'dory', type: 'dance' };

				const product = myTrainingPlanner.searchExercises(searchQuery);

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(0);

			});

		});

		describe('listExercises() Tests', function () {
			it('expect listExercises to throw when the passed property is name', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.listExercises(5, 'name')).to.throw();

			});

			it('expect listExercises to throw when the passed property is not a string', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.listExercises(5, false)).to.throw();

			});

			it('expect listExercises to throw when the passed property is not a gym or pole dance property', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.listExercises(5, 'not a property')).to.throw();

			});

			it('expect listExercises to return an empty array when there are no exercises with that property', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				myTrainingPlanner.addExerciseToDatabase(gymExercise);

				const product = myTrainingPlanner.listExercises(5, 'type');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(0);

			});

			it('expect listExercises to return an array with all exercises when the passed count is higher than the number of exercises', function () {

				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);

				const product = myTrainingPlanner.listExercises(50, 'rest');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(4);
				expect(product[0].name).to.equal('Valid Name Gym New');
				expect(product[1].name).to.equal('Valid Name Pole Dance New');
				expect(product[2].name).to.equal('Valid Name Gym');
				expect(product[3].name).to.equal('Valid Name Pole Dance');

			});

			it('expect listExercises to return an array with the correct number of exercises when the passed count is lower than the number of exercises', function () {
				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);

				const product = myTrainingPlanner.listExercises(2, 'rest');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(2);
				expect(product[0].name).to.equal('Valid Name Gym New');
				expect(product[1].name).to.equal('Valid Name Pole Dance New');
			});

			it('expect listExercises to return an array with the correct number of exercises when the passed count is lower than the number of exercises 2', function () {
				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 5, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 6, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);

				const product = myTrainingPlanner.listExercises(2, 'caloriesBurn');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(2);
				expect(product[0].name).to.equal('Valid Name Gym New');
				expect(product[1].name).to.equal('Valid Name Pole Dance New');
			});

			it('expect listExercises to return an array with the correct number of exercises when no count is passed', function () {
				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExerciseToDatabase([gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);

				const product = myTrainingPlanner.listExercises(undefined, 'rest');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(4);
				expect(product[0].name).to.equal('Valid Name Gym New');
				expect(product[1].name).to.equal('Valid Name Pole Dance New');
				expect(product[2].name).to.equal('Valid Name Gym');
				expect(product[3].name).to.equal('Valid Name Pole Dance');
			});

		});

		describe('getProgram() Tests', function () {

			it('expect getProgram to throw when the passed parameter is not a string or an object', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.getProgram(true)).to.throw();

			});

			it('expect getProgram to throw when the passed parameter is not a valid day of the week', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.getProgram('blabla day')).to.throw();
			});

			it('expect getProgram to throw when the passed object is not a valid combination of properties', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.getProgram({ type: 'easy', numberOfSets: 3 })).to.throw();
			});

			it('expect getProgram to return the correct array of exercises assigned to passed day', function () {

				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);

				let product = myTrainingPlanner.getProgram('monday');

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(4);
				expect(product[0].name).to.equal(validGym.name);
				expect(product[1].name).to.equal(validPoleDance.name);
				expect(product[2].name).to.equal(validGymTwo.name);
				expect(product[3].name).to.equal(validPoleDanceTwo.name);

			});

			it('expect getProgram to return the correct array of days of week which contain correct exercises', function () {



				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				myTrainingPlanner.addExercisetoSchedule('wednesday', [gymExercise, gymExerciseTwo]);

				let product = myTrainingPlanner.getProgram({ primaryMuscleGroup: 'Chest', personalRating: 5 });

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(3);
				expect(product[0]).to.equal('monday');
				expect(product[1]).to.equal('wednesday');
				expect(product[2]).to.equal('sunday');

			});

			it('expect getProgram to return the correct array of days of week which contain correct exercises with improvementStats subproperty', function () {



				const validGymTwo = { name: 'Valid Name Gym New', description: 'Valid Description', rest: 10, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 80 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
				const validPoleDanceTwo = { name: 'Valid Name Pole Dance New', description: 'Valid Description', rest: 20, trainingPartner: 'dory', personalRating: 5, improvementStats: { caloriesBurn: 60, performanceGain: 50 }, difficulty: 'easy', type: 'dance' };

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				gymExercise.update({ name: validGym.name, rest: 30 });
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const gymExerciseTwo = myTrainingPlanner.createExercise(validGymTwo);
				const poleDanceExerciseTwo = myTrainingPlanner.createExercise(validPoleDanceTwo);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, poleDanceExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExerciseTwo, poleDanceExerciseTwo]);
				myTrainingPlanner.addExercisetoSchedule('wednesday', [gymExercise, gymExerciseTwo]);

				let product = myTrainingPlanner.getProgram({ primaryMuscleGroup: 'Chest', personalRating: 5, performanceGain: 80 });

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(3);
				expect(product[0]).to.equal('monday');
				expect(product[1]).to.equal('wednesday');
				expect(product[2]).to.equal('sunday');

			});


		});

		describe('getWeeklySchedule() Tests', function () {

			it('expect getWeeklySchedule to return the schedule in the correct order when there are days with no exercises', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise); // 1
				myTrainingPlanner.addExercisetoSchedule('tuesday', [gymExercise, gymExercise, gymExercise]); // 3
				myTrainingPlanner.addExercisetoSchedule('thursday', [gymExercise, gymExercise, gymExercise, gymExercise]); // 4
				myTrainingPlanner.addExercisetoSchedule('friday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 6
				myTrainingPlanner.addExercisetoSchedule('saturday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 5
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 7

				let product = myTrainingPlanner.getWeeklySchedule();

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(7);
				expect(product[0].day).to.equal('wednesday');
				expect(product[1].day).to.equal('monday');
				expect(product[2].day).to.equal('tuesday');
				expect(product[3].day).to.equal('thursday');
				expect(product[4].day).to.equal('saturday');
				expect(product[5].day).to.equal('friday');
				expect(product[6].day).to.equal('sunday');

			})

			it('expect getWeeklySchedule to return the schedule in the correct order when there are valid exercises in every day', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise); // 1
				myTrainingPlanner.addExercisetoSchedule('tuesday', [gymExercise, gymExercise, gymExercise]); // 3
				myTrainingPlanner.addExercisetoSchedule('wednesday', [gymExercise, gymExercise]); // 2
				myTrainingPlanner.addExercisetoSchedule('thursday', [gymExercise, gymExercise, gymExercise, gymExercise]); // 4
				myTrainingPlanner.addExercisetoSchedule('friday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 6
				myTrainingPlanner.addExercisetoSchedule('saturday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 5
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise, gymExercise]); // 7

				let product = myTrainingPlanner.getWeeklySchedule();

				expect(product).to.be.instanceof(Array);
				expect(product).to.have.length(7);
				expect(product[0].day).to.equal('monday');
				expect(product[1].day).to.equal('wednesday');
				expect(product[2].day).to.equal('tuesday');
				expect(product[3].day).to.equal('thursday');
				expect(product[4].day).to.equal('saturday');
				expect(product[5].day).to.equal('friday');
				expect(product[6].day).to.equal('sunday');


			})

		});

		describe('train() Tests', function () {

			it('expect train to throw when invalid day is passed', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.train('bladay')).to.throw();

			});

			it('expect train to return the correct personalData when only one exercise is present that day', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise);

				let product = myTrainingPlanner.train('monday');

				expect(product).to.exist;
				expect(product.weight).to.equal(19.6);
				expect(product.fatPercentage).to.equal(9.8);
				expect(product.endurance).to.equal(30.8);
				expect(product.strength).to.equal(40.8);

			});

			it('expect train to return the correct personalData when multiple exercises are present that day', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, gymExercise]);


				let product = myTrainingPlanner.train('monday');

				expect(product).to.exist;
				expect(product.weight).to.equal(19.404);
				expect(product.fatPercentage).to.equal(9.702);
				expect(product.endurance).to.equal(32.4);
				expect(product.strength).to.equal(42.4);

			});

		});

		describe('trainWeeks() Tests', function () {

			it('expect trainWeeks to throw when invalid count is passed', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.trainWeeks(undefined)).to.throw

			});

			it('expect trainWeeks to return correct personalData when there are exercises in every day of the week', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise);
				myTrainingPlanner.addExercisetoSchedule('tuesday', [gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('wednesday', [gymExercise, gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('thursday', [gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('friday', [gymExercise, gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('saturday', [gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExercise]);

				let product = myTrainingPlanner.trainWeeks(2);

				expect(product).to.exist;
				expect(product.weight).to.equal(16.405398104565627);
				expect(product.fatPercentage).to.equal(8.202699052282814);
				expect(product.endurance).to.equal(54.79999999999999);
				expect(product.strength).to.equal(64.79999999999998);

			});

			it('expect trainWeeks to return correct personalData when there days with no exercise', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);

				myTrainingPlanner.addExercisetoSchedule('monday', gymExercise);
				myTrainingPlanner.addExercisetoSchedule('wednesday', [gymExercise, gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('friday', [gymExercise, gymExercise, gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('saturday', [gymExercise]);
				myTrainingPlanner.addExercisetoSchedule('sunday', [gymExercise, gymExercise]);

				let product = myTrainingPlanner.trainWeeks(2);

				expect(product).to.exist;
				expect(product.weight).to.equal(14.439145846467154);
				expect(product.fatPercentage).to.equal(7.219572923233577);
				expect(product.endurance).to.equal(70.79999999999998);
				expect(product.strength).to.equal(80.79999999999998);
			});

		});

	});
});