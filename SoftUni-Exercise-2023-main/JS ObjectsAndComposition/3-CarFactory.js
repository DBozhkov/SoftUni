function modifyCar(car){
    let finalCar = {};
    finalCar.model = car.model;

    let engineType = {
        smallEngine: { power: 90, volume: 1800 },
        normalEngine: { power: 120, volume: 2400 },
        monsterEngine: { power: 200, volume: 3500 },
    };

    let carriageType = {
        type: car.carriage,
        color: car.color,
    };

    
    if(Number(car.power) <= 90){
        finalCar['engine'] = engineType.smallEngine;
    } else if(Number(car.power) > 90 && Number(car.power) <= 120){
        finalCar['engine'] = engineType.normalEngine;
    } else{
        finalCar['engine'] = engineType.monsterEngine;
    }
    
    finalCar.carriage = carriageType;
    finalCar['wheels'] = [];

    if(Number(car.wheelsize) % 2 == 0){
        for(let i = 0; i < 4; i++){
            finalCar['wheels'].push(car.wheelsize - 1);
        };
    }else {
        for(let i = 0; i < 4; i++){
            finalCar['wheels'].push(car.wheelsize);
        };
    }
    return finalCar;
}


modifyCar({ model: 'VW Golf II',
  power: 90,
  color: 'blue',
  carriage: 'hatchback',
  wheelsize: 14 }
);
