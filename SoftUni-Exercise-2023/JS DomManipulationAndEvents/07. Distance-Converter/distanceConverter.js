function attachEventsListeners() {
    let inputDistanceElement = document.getElementById('inputDistance');
    let inputUnitsElement = document.getElementById('inputUnits');
    let outputUnitsElement = document.getElementById('outputUnits');
    let outputElement = document.getElementById('outputDistance');
    let button = document.getElementById('convert');


    
    let currValue = 0;
    button.addEventListener('click', outputDistance);

    
    function outputDistance() {
        let inputValue = inputUnitsElement.value;
        let numInputElement = Number(inputDistanceElement.value);

        if (inputValue === 'km') {
            currValue = numInputElement * 1000;
        } else if (inputValue === 'm') {
            currValue = numInputElement;
        } else if (inputValue === 'cm') {
            currValue = numInputElement * 0.01;
        } else if (inputValue === 'mm') {
            currValue = numInputElement * 0.001;
        } else if (inputValue === 'mi') {
            currValue = numInputElement * 1609.34;
        } else if (inputValue === 'yrd') {
            currValue = numInputElement * 0.9144;
        } else if (inputValue === 'ft') {
            currValue = numInputElement * 0.3048;
        } else if (inputValue === 'in') {
            currValue = numInputElement * 0.0254;
        };

        let outputValue = outputUnitsElement.value;

        if (outputValue === 'km') {
            outputElement.value = currValue / 1000;
        } else if (outputValue === 'm') {
            outputElement.value = currValue;
        } else if (outputValue === 'cm') {
            outputElement.value = currValue * 100;
        } else if (outputValue === 'mm') {
            outputElement.value = currValue * 1000;
        } else if (outputValue === 'mi') {
            outputElement.value = currValue / 1609.34;
        } else if (outputValue === 'yrd') {
            outputElement.value = currValue / 0.9144;
        } else if (outputValue === 'ft') {
            outputElement.value = currValue / 0.3048;
        } else if (outputValue === 'in') {
            outputElement.value = currValue / 0.0254;
        };        
    };
}
