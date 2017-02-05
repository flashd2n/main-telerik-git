'use strict';

function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function createCategory(categoryName){
			categories.push({
				name: categoryName,
				booksList: []
			});
		}

		function listBooks() {



			return books;
		}

		function addBook(book) {
			let hasCategory = false;
			let categoryIndex = 0;
			book.ID = books.length + 1;
			books.push(book);

			if(categories.length === 0){
				createCategory(book.category);
				categories[0].booksList.push(book);
			} else {

				for(let i = 0; i < categories.length; i++){
					if(book.category === categories[i].name){
						hasCategory = true;
						categoryIndex = i;
					}
				}

				if(hasCategory){
					categories[categoryIndex].booksList.push(book);
				} else {
					createCategory(book.category);
					categories[categories.length - 1].booksList.push(book);
				}
			}


			return book;
		}

		function listCategories() {

			categories.sort((x, y) => x.ID - y.ID);

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

