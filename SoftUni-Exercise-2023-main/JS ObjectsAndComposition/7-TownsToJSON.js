function convertTownsToJson(array){
    let jsonTowns = [];
    let currObj = {};

    for(let i = 1; i < array.length; i++){
        let currArray = array[i].trim().split('|');
        let tempObj = JSON.parse(JSON.stringify(currObj));

        let name = currArray[1].trim();
        let currLatitude = (Number(currArray[2].trim())).toFixed(2);
        let currLongitude = (Number(currArray[3].trim())).toFixed(2);
        tempObj['Town'] = name;
        tempObj['Latitude'] = currLatitude;
        tempObj['Longitude'] = currLongitude;

        jsonTowns.push(tempObj);
    }
    console.log(JSON.stringify(jsonTowns, function (key, value) {
        if (key == "Latitude") {
            return Number(value);
        } else if (key == "Longitude") {
            return Number(value);
        } else {
            return value;
        }
    }));
};


convertTownsToJson(
    ['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);