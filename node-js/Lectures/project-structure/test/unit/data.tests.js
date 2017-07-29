const expect = require('chai').expect;
const { BaseData } = require('../../data/base/base.data');
const sinon = require('sinon');

describe('Base data get all', () => {
    const ModelClass = class {
    };
    const validator = {
        isValid: () => true,
    };

    let sut = null;
    const items = [1, 2, 3, 4];
    let db = null;

    before(() => {
        db = {
            collection: sinon.stub().returns({
                find: sinon.stub().returns({
                    toArray: sinon.stub().returns(Promise.resolve(items)),
                }),
            }),
        };
    });

    it('expect to return items, when items in db', () => {
        sut = new BaseData(db, ModelClass, validator);
        // act
        return sut.getAll()
            .then((models) => {
                expect(models).to.deep.equal(items);
                expect(db.collection().find.callCount).to.equal(1);
                expect(db.collection().find().toArray.callCount).to.equal(1);
                expect(db.collection().find.calledWith({})).to.equal(true);
            });
    });

    describe('WITH MODELCLASS SET PROPER MOCK', () => {
        let mySut = null;
        let modelStub = null;
        before(() => {
            modelStub = {
                name: {
                    toLowerCase: () => {
                        return 'model';
                    },
                },
                createInstance: sinon.stub().returns(true),
            };

            mySut = new BaseData(db, modelStub, validator);
        });
        it('expect to return items, when items in db AND VIEW MODEL', () => {
            // act
            return mySut.getAll()
                .then((models) => {
                    expect(modelStub.createInstance.callCount).to.equal(4);
                    expect(modelStub.createInstance.calledWith(1)).to.equal(true);
                    expect(modelStub.createInstance.calledWith(2)).to.equal(true);
                    expect(modelStub.createInstance.calledWith(3)).to.equal(true);
                    expect(modelStub.createInstance.calledWith(4)).to.equal(true);
                });
            // assert
        });
    });

    // describe('WITH MODELCLASS SET', () => {
    //     beforeEach(() => {
    //         ModelClass = class {
    //             static createInstance(model) {
    //                 return model + '1';
    //             }
    //         };

    //         sut = new BaseData(db, ModelClass, validator);
    //     });
    //     it('expect to return items, when items in db AND VIEW MODEL', () => {
    //         // act
    //         return sut.getAll()
    //             .then((models) => {
    //                 models.forEach((model, index) => {
    //                     expect(model).to.deep.equal(items[index] + '1');
    //                 });
    //             });
    //         // assert
    //     });
    // });
});
