class BaseData {
    constructor(db, ModelClass, validator) {
        this.db = db;
        this.modelClass = ModelClass;
        this.validator = validator;
        this.collectionName = this._getCollectionName();
        this.collection = this.db.collection(this.collectionName);
    }

    getAll() {
        return this.collection.find({})
            .toArray()
            .then((models) => {
                return models.map((model) => {
                    return this.modelClass.createInstance(model);
                });
            });
    }

    create(data) {
        const model = this.modelClass.createInstance(data);

        if (this._isModelValid(model)) {
            return this.collection.insert(model)
                .then((dbModel) => {
                    return this.modelClass.createInstance(dbModel.ops[0]);
                });
        }
        return Promise.reject('Not a Valid Model');
    }

    _getCollectionName() {
        return this.modelClass.name.toLowerCase() + 's';
    }

    _isModelValid() {
        return true;
    }
}

module.exports = {
    BaseData,
};
