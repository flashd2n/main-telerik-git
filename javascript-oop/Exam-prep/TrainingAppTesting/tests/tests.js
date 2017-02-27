const {expect} = require('chai');
const result = require('../task/task')();
const validTrainingPlannerObject = { weight: 20, fatPercentage: 10, endurance: 30, strength: 40 };
const validExercise = { name: 'Valid Name', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 } };
const validGym = { name: 'Valid Name Gym', description: 'Valid Description', rest: 60, trainingPartner: 'Gosho', personalRating: 5, improvementStats: { caloriesBurn: 50, performanceGain: 50 }, numberOfSets: 5, primaryMuscleGroup: 'Chest', secondaryMuscleGroup: 'Triceps', bestWeight: 75 };
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

		//HERE

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
				expect(myTrainingPlanner.schedule).to.have.length(1);
				expect(myTrainingPlanner.schedule[0].dailyExercises[0].name).to.be.equal(gymExercise.name)

			});

			it('expect addExercisetoSchedule to add all exercise to the correct day when all passed exercises are valid', function () {
				const myTrainingPlanner = result.createTrainingPlanner(validTrainingPlannerObject);
				const gymExercise = myTrainingPlanner.createExercise(validGym);
				const poleDanceExercise = myTrainingPlanner.createExercise(validPoleDance);

				myTrainingPlanner.addExercisetoSchedule('monday', [gymExercise, poleDanceExercise]);

				expect(myTrainingPlanner.schedule).to.be.instanceof(Array);
				expect(myTrainingPlanner.schedule).to.have.length(2);
				expect(myTrainingPlanner.schedule[0].dailyExercises[0].name).to.be.equal(gymExercise.name)
				expect(myTrainingPlanner.schedule[0].dailyExercises[1].name).to.be.equal(poleDanceExercise.name)
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