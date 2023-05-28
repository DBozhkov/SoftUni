function sameNums(input) {
    let numberString = input.toString();
    let isValid = true;
    let sum = 0;
    let comparer = numberString[0];

    for (let i = 0; i < numberString.length; i++) {
        sum += +numberString[i];
        if (numberString[i] !== comparer){
            isValid = false;
        }
    }
    console.log(isValid);
    console.log(sum);
}

sameNums(2222222);
