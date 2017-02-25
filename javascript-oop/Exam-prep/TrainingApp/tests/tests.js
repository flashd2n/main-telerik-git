const {expect} = require('chai');
const result = require('../task/task')();

describe('Training Planner Tests', function () {

	describe('Exercise Class Tests', function () {

		it('Skeleton Test', function () {
			expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
		});

	});

	describe('Gym Class Tests', function () {
		it('Skeleton Test', function () {
			expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
		});
	});

	describe('Pole Dancing Class Tests', function () {
		it('Skeleton Test', function () {
			expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
			expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
		});
	});

	describe('Training Planner Class Tests', function () {
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