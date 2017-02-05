/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

'use strict';

function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function createCategory(categoryName){
			categories.push(categoryName);
		}

		function checkRepeatingISBN(isbn){
			for(let i = 0; i < books.length; i++){
				if(books[i].isbn === isbn){
					return true;
				}
			}
			return false;
		}

		function checkRepeatingTitle(title){
			for(let i = 0; i < books.length; i++){
				if(books[i].title === title){
					return true;
				}
			}
			return false;
		}

		function listBooks(sortOption) {

			let result = [];

			if(sortOption === undefined){
				return books;
			}

			if('category' in sortOption){

				for(let i = 0; i < books.length; i++){

					if(books[i].category === sortOption.category){
						result.push(books[i]);
					}
				}

				return result;

			} else if('author' in sortOption){

				for(let i = 0; i < books.length; i++){

					if(books[i].author === sortOption.author){
						result.push(books[i]);
					}
				}
				return result;
			}
		}

		function addBook(book) {

			if(book.title.length < 2 || book.title.length > 100){
				throw new Error ('Provided Book Title is not valid');
			}
			if(book.category < 2 || book.category > 100){
				throw new Error ('Provided Book Category is not valid');
			}
			if(book.author === null || book.author === undefined || book.author === ''){
				throw new Error ('Unvalid author name');
			}
			if(book.isbn.length < 10 || book.isbn.length > 13){
				throw new Error ('Unvalid ISBN');
			}

			if(checkRepeatingISBN(book.isbn)){
				throw new Error ('Repeating ISBN');
			}
			if(checkRepeatingTitle(book.title)){
				throw new Error ('Repeating Title');
			}

			let hasCategory = false;
			book.ID = books.length + 1;
			books.push(book);

			if(categories.length === 0){
				createCategory(book.category);
			} else {

				for(let i = 0; i < categories.length; i++){
					if(book.category === categories[i]){
						hasCategory = true;
					}
				}

				if(!hasCategory){
					createCategory(book.category);
				}
			}
			return book;
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
