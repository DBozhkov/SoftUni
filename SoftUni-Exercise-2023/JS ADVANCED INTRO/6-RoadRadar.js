function getSpeedLimit(speed, area) {
    let currSpeed = speed;
    let areaName = area;
    let inputMessage;
    let status;
    let speedDifference;

    if (areaName == 'motorway') {
        speedDifference = currSpeed - 130;
        if (speedDifference <= 0) {
            inputMessage = `Driving ${currSpeed} km/h in a ${130} zone`;
        } else {
            if (speedDifference <= 20) {
                status = 'speeding';
            } else if (speedDifference > 20 && speedDifference <= 40) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            inputMessage = `The speed is ${speedDifference} km/h faster than the allowed speed of ${130} - ${status}`;
        }
    } else if (areaName == 'interstate') {
        speedDifference = currSpeed - 90;
        if (speedDifference <= 0) {
            inputMessage = `Driving ${currSpeed} km/h in a ${90} zone`;
        } else {
            if (speedDifference <= 20) {
                status = 'speeding';
            } else if (speedDifference > 20 && speedDifference <= 40) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            inputMessage = `The speed is ${speedDifference} km/h faster than the allowed speed of ${90} - ${status}`;
        }
    } else if (areaName == 'city') {
        speedDifference = currSpeed - 50;
        if (speedDifference <= 0) {
            inputMessage = `Driving ${currSpeed} km/h in a ${50} zone`;
        } else {
            if (speedDifference <= 20) {
                status = 'speeding';
            } else if (speedDifference > 20 && speedDifference <= 40) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            inputMessage = `The speed is ${speedDifference} km/h faster than the allowed speed of ${50} - ${status}`;
        }
    } else if (areaName == 'residential') {
        speedDifference = currSpeed - 20;
        if (speedDifference <= 0) {
            inputMessage = `Driving ${currSpeed} km/h in a ${20} zone`;
        } else {
            if (speedDifference <= 20) {
                status = 'speeding';
            } else if (speedDifference > 20 && speedDifference <= 40) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            inputMessage = `The speed is ${speedDifference} km/h faster than the allowed speed of ${20} - ${status}`;
        }
    }
    console.log(inputMessage);
}

getSpeedLimit(120, 'interstate');