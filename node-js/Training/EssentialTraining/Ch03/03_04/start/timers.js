let waitTime = 3000;
let currentWait = 0;
let waitInterval = 500;

console.log('Legend ');
console.log('..what for it...');

let interval = setInterval(function(){
    
    currentWait += waitInterval;
    
    let progress = ((currentWait / waitTime) * 100).toFixed(2) + '%';
    
    WriteProgress(progress)
    
}, waitInterval);

setTimeout(function(){
    
    clearInterval(interval);
    WriteProgress('100%\n')
    console.log('ary');
    
}, waitTime);

function WriteProgress(progress){
    process.stdout.clearLine();
    process.stdout.cursorTo(0);
    process.stdout.write(progress);
}

WriteProgress('0%');