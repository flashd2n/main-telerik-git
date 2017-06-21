console.log(process.argv);

let inputParams = GetInputArgs();

//console.log(`User: ${inputParams.user} says ${inputParams.greeting}!`);




function GetInputArgs(){
    let args = process.argv;
    
    const userFlag = '--user';
    const greetingFlag = '--greeting'
    
    let userFlagPosition = args.indexOf(userFlag);
    
    let userValue = args[userFlagPosition + 1];
    
    let greetingFlagPosition = args.indexOf(greetingFlag);
    
    let greetingValue = args[greetingFlagPosition + 1];
    
    return {
        user: userValue,
        greeting: greetingValue
    };
    
}