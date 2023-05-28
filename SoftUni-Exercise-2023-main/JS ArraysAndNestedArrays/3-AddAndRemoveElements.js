function AddOrRemove(array){
    let num = 1;
    let arr = [];
    for(let el of array){
        if(el === 'add'){
            arr.push(num)
        }else if(el === 'remove'){
            arr.pop();
        }
        num++;
    }

    if(arr.length == 0){
        console.log('Empty');
    }else{
        console.log(arr.join('\r\n'));
    };
}

AddOrRemove(['add', 
'add', 
'add', 
'add']
);