function printNthElementArray(array, step) {
    let arr = array;
    let index = step;
    let newArr = [];

    for (let i = 0; i < arr.length; i += index) {
        newArr.push(arr[i]);
    }

    return newArr;
}

printNthElementArray(['5',
    '20',
    '31',
    '4',
    '20'],
    2
)