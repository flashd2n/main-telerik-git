'use strict';

// $(function () {

//     let template = $('#itemTemplate').html();

//     let renderer = Handlebars.compile(template);

//     let result = renderer({
//         employees: [{
//             item: 'some item',
//             description: 'some description',
//             price: 'very many moneys',
//             fulltime: true,
//             cool: 'yea'
//         }, {
//             item: 'another item',
//             description: 'another description',
//             price: 'even more very many moneys',
//             fulltime: false,
//             cool: ''
//         }]
//     });

//     $('#container').html(result);

// });


// $(function () {

//     Handlebars.registerHelper('prodQuantity', function(productData){

//         if(productData.quantity >= 100){
//             return 'we have a lot of this stuff';
//         }
//         return 'hurry, we are running low on this stuff';

//     });


//     let template = $('#itemTemplate').html();

//     let renderer = Handlebars.compile(template);

//     let result = renderer({
//        item: 'Item Name',
//        description: 'Item description',
//        data: {
//            price: 9000,
//            inStock: false,
//            quantity: 42
//        }
//     });

//     $('#container').html(result);

// });

$(function(){

    let renderer = Handlebars.templates['precomp'];

    let result = renderer({
        item: 'my item',
        description: 'my description',
        price: 9000
    });

    $('#container').html(result);

});