class BaseModel {
    get id() {
        return this._id + '';
    }

    static createInstance(data) {
        const model = new this();

        Object.keys(data)
            .forEach((prop) => {
                model[prop] = data[prop];
            });
        return model;
    }
}

module.exports = {
    BaseModel,
};
