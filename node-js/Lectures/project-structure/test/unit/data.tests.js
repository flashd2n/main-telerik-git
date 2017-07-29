const { expect } = require('chai');
const { BaseData } = require('../../data/base/base.data');
const sinon = require('sinon');

describe('Base data get all', () => {
    const db = {
        collection: () => { },
    };
    let ModelClass = null;
    let validator = null;
    let data = null;
    let items = [];

    const toArray = () => {
        return Promise.resolve(items);
    };

    const find = () => {
        return {
            toArray,
        };
    };

    beforeEach(() => {
        items = [1, 2, 3, 4];
        validator = {
            isValid: () => true,
        };

        ModelClass = class {
        };

        sinon.stub(db, 'collection')
            .callsFake(() => {
                return {
                    find,
                };
            });
        // arrange
        data = new BaseData(db, ModelClass, validator);
    });

    it('expenct to return items, when items in db', () => {
        // act
        return data.getAll()
            .then((models) => {
                expect(models).to.deep.equal(items);
            });
        // assert
    });
});
