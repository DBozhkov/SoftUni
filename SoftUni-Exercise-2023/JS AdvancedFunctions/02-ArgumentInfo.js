function getArgumentInfo() {
    let infoObj = {};
    let typesObj = {};
    for (const el of arguments) {
        console.log(`${(typeof el)}: ${el}`);
        if (!typesObj.hasOwnProperty(typeof el)) {
            typesObj[(typeof el)] = 1;
        } else {
            typesObj[(typeof el)]++;
        };
    };

    let sortedObj = Object.keys(typesObj)
        .sort((a, b) => typesObj[b] - typesObj[a])
        .reduce((acc, key) => {
            acc[key] = typesObj[key];

            return acc;
        }, {});

    for (const key in sortedObj) {
        console.log(`${key} = ${sortedObj[key]}`);
    };
}


getArgumentInfo({ name: 'bob' }, 3.333, 9.999);