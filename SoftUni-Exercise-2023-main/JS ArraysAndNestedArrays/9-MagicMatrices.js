function returnMagicalMatrix(matrix) {
    let isMagical = true;
    let initialSum = 0;
    matrix[0].forEach(x => initialSum += x);

    for (let row = 0; row < matrix.length; row++) {
        let tempColSum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            tempColSum += Number(matrix[row][col]);
        }
        if (tempColSum != initialSum) {
            isMagical = false;
            console.log(isMagical);
            return;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let tempRowSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            tempRowSum += Number(matrix[row][col]);
        }
        if (tempRowSum != initialSum) {
            isMagical = false;
            console.log(isMagical);
            return;
        }
    }
    return isMagical;
}

returnMagicalMatrix([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);