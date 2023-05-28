function createInventory(array){
    let heroInfo = [];

    for (const el of array) {
        let [name, level, items] = el.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        heroInfo.push({name, level, items});
    }

    console.log(JSON.stringify(heroInfo));
};


createInventory(['Isacc / 25 / Apple',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);
