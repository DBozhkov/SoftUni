function timeToUni(steps, footprintsLength, speed){

    let distance = steps * footprintsLength;
    let speedPerSecond = speed * 1000 / 3600;
    let restTime = Math.floor(distance / 500) * 60;
    let time = (distance / speedPerSecond) + restTime;

    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, '0');
    let minutes = Math.floor(time / 60).toFixed(0).padStart(2, '0');
    let seconds = (time % 60).toFixed(0).padStart(2, '0');

    console.log(`${hours}:${minutes}:${seconds}`);
    
}

timeToUni(2564, 0.70, 5.5);