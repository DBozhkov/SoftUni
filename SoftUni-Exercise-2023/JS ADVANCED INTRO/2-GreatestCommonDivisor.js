function greatestDivisor(firstNum, secondNum){
    let number1 = firstNum;
    let number2 = secondNum;
    let biggerNum = 0;
    let maxDiv = 0;

    if(number1 > number2){
        biggerNum = number1;
    }else{
        biggerNum = number2;
    }
    for(i = 1; i < biggerNum; i++){
        if(number1 % i == 0 && number2 % i == 0){
            maxDiv = i;
        }
    }
    console.log(maxDiv)
}

greatestDivisor(15, 5);