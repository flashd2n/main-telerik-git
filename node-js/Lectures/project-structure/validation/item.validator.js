const validate = (data) => {
    if (typeof data === undefined) {
        throw new Error('validation');
    }

    if (typeof data.text !== 'string') {
        throw new Error('validation');
    }

    if (data.text.length < 3) {
        throw new Error('validation');
    }
};

module.exports = {
    validate,
};
