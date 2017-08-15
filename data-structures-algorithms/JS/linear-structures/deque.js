// using [head, tail) interval for buffer

class Deque {
    constructor(initlen) {
        this._validateInitLen(initlen);
        const DEFAULT_SIZE = 4;
        this._buffer = Array.from({ length: initlen || DEFAULT_SIZE });
        this._size = 0;
        this._head = 0;
        this._tail = 0;
    }

    pushBack(item) {
        if (this._size === this._buffer.length) {
            this._resizeBuffer();
        }

        this._buffer[this._tail] = item;
        this._tail = this._incrementIndex(this._tail);

        ++this._size;

        return this;
    }

    pushFront(item) {
        if (this._size === this._buffer.length) {
            this._resizeBuffer();
        }

        this._head = this._decrementIndex(this._head);
        this._buffer[this._head] = item;

        ++this._size;

        return this;
    }

    popFront() {
        this._validatePop();
        const returnValue = this._buffer[this._head];
        this._head = this._incrementIndex(this._head);

        --this._size;

        return returnValue;
    }

    popBack() {
        this._validatePop();
        this._tail = this._decrementIndex(this._tail);
        const returnValue = this._buffer[this._tail];

        --this._size;

        return returnValue;
    }

    isEmpty() {
        return this._size === 0;
    }

    _resizeBuffer() {
        const newBufferSize = this._buffer.length * 2;
        const newBuffer = Array.from({ length: newBufferSize });

        let index = this._head;

        for (let i = 0; i < this._buffer.length; i++) {
            newBuffer[i] = this._buffer[index];
            index = this._incrementIndex(index);
        }

        this._buffer = newBuffer;
        this._head = 0;
        this._tail = this._size;
    }

    _incrementIndex(value) {
        let index = value + 1;

        if (index >= this._buffer.length) {
            index = 0;
        }

        return index;
    }

    _decrementIndex(value) {
        let index = value - 1;

        if (index < 0) {
            index = this._buffer.length - 1;
        }

        return index;
    }

    _validatePop() {
        if (this._size === 0) {
            throw new Error('Deque is empty, cannot pop');
        }
    }

    _validateInitLen(value) {
        if (!value) {
            return;
        }

        if (isNaN(value) || typeof value !== 'number') {
            throw new Error('Supplied initial length is not a number');
        }

        if (!Number.isInteger(value)) {
            throw new Error('Supplied inital length is not an integer');
        }

        if (value <= 0) {
            throw new Error('Supplied initial length is not a positive integer');
        }
    }
}

const getDeque = () => {
    return new Deque();
};

module.exports = {
    Deque, getDeque,
};
