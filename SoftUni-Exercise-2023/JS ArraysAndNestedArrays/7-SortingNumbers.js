function sortNumbers(array) {
    let finalArr = [];

    array.sort((a, b) => a - b);
    let firstIndex = 0;
    let finalIndex = array.length - 1;

    while (array.length !== finalArr.length) {
        finalArr.push(array[firstIndex]);
        if(array.length == finalArr.length){
            break;
        }
        finalArr.push(array[finalIndex]);
        firstIndex++;
        finalIndex--;
    }
    return finalArr;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);