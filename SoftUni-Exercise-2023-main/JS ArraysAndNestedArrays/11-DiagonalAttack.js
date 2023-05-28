function printFinalMatrix(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;
    let leftDiagonalArray = [];
    let rightDiagonalArray = [];

    for (let k = 0; k < matrix.length; k++) {
        matrix[k] = matrix[k].split(' ').map(x => Number(x));
    }

    for (let i = 0; i < matrix.length; i++) {
        leftDiagonalSum += Number(matrix[i][i]);
        rightDiagonalSum += Number(matrix[i][matrix.length - i - 1]);
    }

    if (leftDiagonalSum === rightDiagonalSum) {
        //     for (let i = 0; i < matrix.length; i++) {
        //         leftDiagonalArray.push(matrix[i].splice([i], 1, 'undefined'));
        //     }

        //     for (let j = 0; j < matrix.length; j++) {
        //         rightDiagonalArray.push(matrix[j].splice([matrix.length - j - 1], 1, 'undefined'));
        //     }

        //     for (let m = 0; m < matrix.length; m++) {
        //         matrix[m] = matrix[m].map(x => x = leftDiagonalSum);
        //     }

        //     for (let j = 0; j < matrix.length; j++) {
        //         matrix[j][matrix.length - j - 1] = rightDiagonalArray[j][0];
        //     }
        //     for (let i = 0; i < matrix.length; i++) {
        //         matrix[i][i] = leftDiagonalArray[i][0];
        //     }

        //     for (let row = 0; row < matrix.length; row++) {
        //         console.log(matrix[row].join(' '));
        //     }
        // } else {
        //     for (let row = 0; row < matrix.length; row++) {
        //         console.log(matrix[row].join(' '));
        //     }

        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if ((col !== row) && (col !== matrix.length - row - 1)) {
                    matrix[row][col] = leftDiagonalSum;
                }
            }
        }

        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '));
        }
    } else {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '));
        }
    }
}


    printFinalMatrix([
        '5 3 12 3 1',
        '11 4 23 2 5',
        '101 12 3 21 10',
        '1 4 5 2 2',
        '5 22 33 11 1']
    );