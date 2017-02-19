function solve(){            
	return {
		getBook: function (name, isbn, genre, description) {
			//return a book instance
		},
		getMedia: function (name, rating, duration, description) {
			//return a media instance
		}
		getBookCatalog: function (name) {
			//return a book catalog instance
		},
		getMediaCatalog: function (name) {
			//return a media catalog instance
		}
	};
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

console.log(catalog.search('js')); 
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'))
//returns []
