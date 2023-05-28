function generateReport() {
    let tableRows = document.querySelectorAll('tbody tr');
    let headerElements = document.querySelectorAll('table thead tr th input');
    let rowsArray = [];

    for (let rowIndex = 0; rowIndex < tableRows.length; rowIndex++) {

        let currentObj = {};
        for (let colIndex = 0; colIndex < headerElements.length; colIndex++) {
            let isChecked = headerElements[colIndex].checked;

            if (isChecked) {
                let currentCellData = tableRows[rowIndex].children[colIndex].textContent;
                let currentHeader = headerElements[colIndex].name;
                currentObj[currentHeader] = currentCellData;
            }
        }
        
        rowsArray.push(currentObj);
    }
    let resultJSON = JSON.stringify(rowsArray, null, 2);

    document.getElementById('output').textContent = resultJSON;
};