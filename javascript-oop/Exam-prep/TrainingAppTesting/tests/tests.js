const {expect} = require('chai');
const result = require('../task/task')();
const validTrainingPlannerObject = { weight: 20, fatPercentage: 10, endurance: 30, strength: 40 };
const validExercise = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 } };
const validGym = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
const validPoleDance = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };


describe('Training Planner Tests', function () {

	describe('Initiation Properties Tests', function () {

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

		});

		it('expect createTrainingPlanner with invalid weigth to throw 2', function () {

			expect(() => result.createTrainingPlanner({ weight: '2', fatPercentage: 20, endurance: 20, strength: 20 })).to.throw();

		});

		it('expect createTrainingPlanner with invalid fatPercentage to throw', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 41, endurance: 20, strength: 20 })).to.throw();

		});

		it('expect createTrainingPlanner with invalid fatPercentage to throw 2', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: undefined, endurance: 20, strength: 20 })).to.throw();

		});

		it('expect createTrainingPlanner with invalid endurance to throw', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: null, strength: 20 })).to.throw();

		});

		it('expect createTrainingPlanner with invalid endurance to throw 2', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: -1, strength: 20 })).to.throw();

		});

		it('expect createTrainingPlanner with invalid strength to throw', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: NaN })).to.throw();

		});

		it('expect createTrainingPlanner with invalid strength to throw 2', function () {

			expect(() => result.createTrainingPlanner({ weight: 50, fatPercentage: 20, endurance: 20, strength: true })).to.throw();

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

		it('expect createExercise with invalid passed parameter to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise('object')).to.throw();

		});

		it('expect createExercise with invalid passed parameter to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise(true)).to.throw();

		});

		it('expect createExercise with invalid gym requirements to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', difficulty: 'dorylevel' })).to.throw();

		});

		it('expect createExercise with invalid poledance requirements to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, primaryMuscleGroup: 'dorylevel', type: 'dance' })).to.throw();

		});

		it('expect createExercise with invalid name to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'gosho#pencho', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid name to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: '', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid description to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: undefined, rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid description to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: {description: 'something'}, rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid rest to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: NaN, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid rest to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 120, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid trainingPartner to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: null, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid trainingPartner to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gos%ho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});


		it('expect createExercise with invalid personalRating to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: -1, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid personalRating to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: null, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

				//	CONTINUE HERE

		it('expect createExercise with invalid improvementStats to throw', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

		it('expect createExercise with invalid improvementStats to throw 2', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

		});

	});



























	describe('Initiation Methods Tests', function () {
		it('Skeleton Test', function () {
			expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
		});
	});

	describe('Tests of Correct Method Behaviour', function () {
		describe('Constructor Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});


		describe('createExercise() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('addExerciseToDatabase() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('addExercisetoSchedule() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('updateExercise() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('getAllExercises() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('searchExercises() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('listExercises() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('getProgram() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('getWeeklySchedule() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('train() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

		describe('trainWeeks() Tests', function () {
			it('Skeleton Test', function () {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});
		});

	});
});