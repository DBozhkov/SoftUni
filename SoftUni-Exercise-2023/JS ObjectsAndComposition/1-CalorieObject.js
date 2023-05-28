function getCalories(input) {
    let foodCals = {};
    let productName;

    for(let i = 0; i < input.length; i++){
        if(i % 2 == 0){
            productName = input[i];
            foodCals[productName] = ' ';
        }else{
            foodCals[productName] = Number(input[i]);
        }
    }

    return foodCals;
}
getCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);