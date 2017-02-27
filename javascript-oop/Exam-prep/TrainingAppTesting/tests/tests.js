const {expect} = require('chai');
const result = require('../task/task')();
const validTrainingPlannerObject = { weight: 20, fatPercentage: 10, endurance: 30, strength: 40 };
const validExercise = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 } };
const validGym = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
const validPoleDance = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };


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

		});


		describe('Exercise Creation Tests', function () {
			it('expect createExercise with invalid passed parameter to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise('object')).to.throw();

			});

			it('expect createExercise with invalid passed parameter to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise(true)).to.throw();

			});

			it('expect createExercise with invalid passed parameter combination to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 3, type: 'dance' })).to.throw();

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

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: { description: 'something' }, rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

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

			it('expect createExercise with invalid improvementStats: caloriesBurn to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: -1, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid improvementStats: performanceGain to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: NaN }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});
		});

		describe('Gym Exercise Creation Tests', function () {

			it('expect createExercise with invalid numberOfSets to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: NaN, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid numberOfSets to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 10, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid primaryMuscleGroup to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'che$st', secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid primaryMuscleGroup to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: { chest: 'chest' }, secondaryMuscleGroup: 'Triceps', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid secondaryMuscleGroup to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: '', bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid secondaryMuscleGroup to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: NaN, bestWeight: 75 })).to.throw();

			});

			it('expect createExercise with invalid bestWeight to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 101 })).to.throw();

			});

			it('expect createExercise with invalid bestWeight to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: undefined })).to.throw();

			});

			it('expect new GymExercise object to have all valid properties', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const gymExercise = myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 });

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
				expect(gymExercise.bestWeight).to.equal(75);



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

			});

			it('expect createExercise with invalid difficulty to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 42, type: 'dance' })).to.throw();

			});

			it('expect createExercise with invalid type to throw', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dances' })).to.throw();

			});

			it('expect createExercise with invalid type to throw 2', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				expect(() => myTrainingPlanner.createExercise({ name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: undefined })).to.throw();

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
			expect(myTrainingPlanner.addExerciseToDatabase).to.have.length(0); // because when function has a single REST operator as a parameter, length returns 0


		});

		it('expect new myTrainingPlanner object ot have correct addExercisetoSchedule method', function () {

			const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

			expect(myTrainingPlanner.addExercisetoSchedule).to.exist;
			expect(myTrainingPlanner.addExercisetoSchedule).to.be.a('function');
			expect(myTrainingPlanner.addExercisetoSchedule).to.have.length(1); // because when function has a "normal" parameter and a single REST operator as a parameter, length returns 1

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

				const toUpdate = {description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };
				
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

				const toUpdate = { name: 'Valid Name', description: 'Valid Description', rest: 60, personalRating: 10, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };
				
				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

			it('expect update to throw when invalid name is provided, but other properties are not valid 4', function () {

				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);

				const myPoleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				const toUpdate = { name: '', description: 'Valid Description', rest: 60, personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, difficulty: 'dorylevel', type: 'dance' };
				
				expect(() => myPoleDanceExercise.update(toUpdate)).to.throw();

			});

		});

		// HERE

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