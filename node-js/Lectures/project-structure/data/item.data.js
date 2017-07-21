const { BaseData } = require('./base/base.data');
const { Item } = require('../models/item.model');

class ItemsData extends BaseData {
    constructor(database, validator) {
        super(database, Item, validator);
    }

    _isModelValid(model) {
        try {
            this.validator(model);
        } catch (error) {
            return false;
        }
        return true;
    }
}

module.exports = {
    ItemsData,
};
