function solve(args){
    let temp;
    
    for(let i = 0; i < 3; i += 1){
        args[i] = Number(args[i]);
    }
    
    for(let i = 0; i < 3; i += 1){
        
        for(let j = i + 1; j < 3; j += 1){
            
            if(args[i] < args[j]){
                temp = args[i];
                args[i] = args[j];
                args[j] = temp;
            }   
        }
    }
    console.log(args[0] + " " + args[1] + " " + args[2]);
}