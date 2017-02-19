'use strict';

function solve() {

    const generateID = (function () {
        let id = 0;
        return function () {
            ++id;
            return id;
        };
    })();

    const VALIDATOR = {
        validateString: function (description) {
            if (typeof description !== `string` || description === `` || description === null) {
                throw new Error(`Description must be a string and cannot be empty`);
            }
        },
        validateIsStringAndLength: function (string, min, max) {
            this.validateString(string);
            if (string.length < min || string.length > max) {
                throw new Error(`String is outside length boundaries`);
            }
        },
        validateIsbn: function (isbn) {
            if (typeof isbn !== `string`) {
                throw new Error(`ISBN must be a string`);
            }
            if (isbn.length !== 10) {
                if (isbn.length !== 13) {
                    throw new Error(`ISBN must be 10 or 13 characters long`);
                }
            }
            if(!/^\d+$/.test(isbn)){
                throw new Error(`ISBN must contain only digits`);
            }
        },
        validateIsNumber: function(number){
            if(typeof number !== 'number'){
                throw new Error('Provided number is not a number');
            }
            if(number <= 0){
                throw new Error('Number cannot be less than zero');
            }
        },
        validateNumberRange: function(number, min, max){
            this.validateIsNumber(number);
            if(number < min || number > max){
                throw new Error(`Number is outside set boundaries`);
            }
        }
    };

    class Item {
        constructor(name, description) {

            this._id = generateID();
            this.name = name;
            this.description = description;
        }

        set name(value) {
            VALIDATOR.validateIsStringAndLength(value, 2, 40);
            this._name = value;
        }

        get name() {
            return this._name;
        }

        set description(value) {
            VALIDATOR.validateString(value);
            this._description = value;
        }

        get description() {
            return this._description;
        }

        get id(){
            return this._id;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        set isbn(value) {
            VALIDATOR.validateIsbn(value);
            this._isbn = value;
        }
        get isbn() {
            return this._isbn;
        }
        set genre(value) {
            VALIDATOR.validateIsStringAndLength(value, 2, 20);
            this._genre = value;
        }
        get genre() {
            return this._genre;
        }

    }

    class Media extends Item {
        constructor(name, rating, duration, description){
            super(name, description);
            this.duration = duration;
            this.rating = rating;
        }

        set duration(value){
            VALIDATOR.validateIsNumber(value);
            this._duration = value;
        }
        get duration(){
            return this._duration;
        }
        set rating(value){
            VALIDATOR.validateNumberRange(value, 1, 5);
            this._rating = value;
        }
        get rating(){
            return this._rating;
        }


    }

    class Catalog {
        constructor(name){
            this.name = name;
            this._id = generateID();
            this._items = [];
        }

        set name(value){
            VALIDATOR.validateIsStringAndLength(value, 2, 40);
            this._name = value;
        }
        get name(){
            return this._name;
        }
        get id(){
            return this._id;
        }

        get items(){
            return this._items;
        }

        add(...items){ // need testing

            if(Array.isArray(items[0])){
                items = items[0];
            }

            if(items.length === 0){
                throw new Error('No items are passed');
            }

            items.forEach(function(x){
                if(typeof x !== `object`){
                    throw new Error(`Passed items is not an object`);
                }

                VALIDATOR.validateIsStringAndLength(x.name, 2, 40);
                VALIDATOR.validateString(x.description);
                VALIDATOR.validateNumberRange(x.id, 0);
            });

            this._items.push(...items);
            return this;
        }

        find(criteria){ // need testing

            if(typeof criteria === `object`){

                return this.items.filter(function(x){
                    return (!criteria.hasOwnProperty(`id`) || x.id === criteria.id) && (!criteria.hasOwnProperty(`name`) || x.name === criteria.name);
                });
            }
            
            VALIDATOR.validateIsNumber(criteria);
            return this.items.find(x => x.id === criteria) || null;

        }

        search(pattern){

            VALIDATOR.validateIsStringAndLength(pattern, 1);

            return this.items.filter(function(x){

                return (x.name.toLowerCase().indexOf(pattern.toLowerCase()) >=0) || (x.description.toLowerCase().indexOf(pattern.toLowerCase()) >= 0);

            });
        }
    }

    class BookCatalog extends Catalog{
        constructor(name){
            super(name);
        }

        add(...books){ // need testing

            if(Array.isArray(books[0])){
                books = books[0];
            }

            if(books.length === 0){
                throw new Error('No items are passed');
            }

            books.forEach(function(x){
                if(typeof x !== `object`){
                    throw new Error(`Passed items is not an object`);
                }
                VALIDATOR.validateIsbn(x.isbn);
                VALIDATOR.validateIsStringAndLength(x.genre, 2, 20);
            });

            return super.add(books);
        }

        getGenres(){
            return this.items.map(x => x.genre.toLowerCase()).slice().sort().filter((genre, index, array) => genre !== array[index - 1]);
        }

        find(criteria){

            if(typeof criteria === 'object'){
                let books = super.find(criteria);

                if(criteria.hasOwnProperty('genre')){
                    return this.items.filter(x => x.genre === criteria.genre);
                }
                return books;

            }
            return super.find(criteria);
        }

    }

    class MediaCatalog extends Catalog{
        constructor(name){
            super(name);
        }

        add(...media){ // need testing

            if(Array.isArray(media[0])){
                media = media[0];
            }

            if(media.length === 0){
                throw new Error('No items are passed');
            }

            media.forEach(function(x){
                if(typeof x !== `object`){
                    throw new Error(`Passed items is not an object`);
                }
                VALIDATOR.validateIsNumber(x.duration);
                VALIDATOR.validateNumberRange(x.rating, 1, 5);
            });

            return super.add(media);
        }

        getTop(count){
            VALIDATOR.validateNumberRange(count, 0);

            const sorted = this.items.slice().sort((x, y) => y.rating - x.rating).map(function(x){
                return {
                    name: x.name,
                    id: x.id
                };
            });

            return sorted.splice(0, count);
        }

        getSortedByDuration(){

            this.items.slice().sort(function(x, y){
                if(x.duration === y.duration){
                    return x.id - y.id;
                }
                return y.duration - x.duration;
            });
        }

		find(criteria) {
			if(typeof criteria === 'object') {
				const medias = super.find(criteria);
				if(criteria.hasOwnProperty('rating')) {
					return medias.filter(media => media.rating === criteria.rating);
				}
				return medias;
			}
			return super.find(criteria);
		}
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    };
}