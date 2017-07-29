class BaseData {
    constructor(db, ModelClass, validator) {
        this.db = db;
        this.modelClass = ModelClass;
        this.validator = validator;
        this.collectionName = this._getCollectionName();
        this.collection = this.db.collection(this.collectionName);
    }

    // filterBy(props) {
    //     return this.collection.find(props)
    //         .toArray();
    // }

    getAll() {
        const result = this.collection.find({})
            .toArray();
        if (this.modelClass.createInstance) {
            return result.then((models) => {
                return models.map((model) => {
                    return this.modelClass.createInstance(model);
                });
            });
        } else {
            return result;
        }
    }

    // create(data) {
    //     // const model = this.modelClass.createInstance(data);

    //     // if (this._isModelValid(model)) {
    //     //     return this.collection.insert(model)
    //     //         .then((dbModel) => {
    //     //             return this.modelClass.createInstance(dbModel.ops[0]);
    //     //         });
    //     // }
    //     // return Promise.reject('Not a Valid Model');


    // }

    _getCollectionName() {
        return this.modelClass.name.toLowerCase() + 's';
    }
}

module.exports = {
    BaseData,
};
