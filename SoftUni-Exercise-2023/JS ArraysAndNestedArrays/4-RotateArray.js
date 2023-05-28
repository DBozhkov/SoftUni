function rotateArray(array, numberOfRotations){
    let rotations = numberOfRotations;

    for(let i = 0; i < rotations; i++){
        let temp = array.pop();
        array.unshift(temp);
    }
    console.log(array.join(' '));
}

rotateArray(['1', 
'2', 
'3', 
'4'], 
2
);