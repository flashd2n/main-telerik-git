let questions = [
    'What is you name?',
    'What is your fav hobby?',
    'What is your fav color?'
];

let answers = [];

process.stdin.on('data', function(data){
   
    answers.push(data.toString().trim());
   
    if(answers.length < questions.length){
       Ask(answers.length);
    } else{
        console.log(answers);
        process.exit();
    }
});

Ask(0);

function Ask(index){
    process.stdout.write(`\n\n${questions[index]}`);
    process.stdout.write('  >  ');
}















