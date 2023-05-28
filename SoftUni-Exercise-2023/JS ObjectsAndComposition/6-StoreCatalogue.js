function getStorageCatalogue(array) {
    let catalogue = [];
    for (const el of array) {
        let [productName, productPrice] = el.split(' : ');
        productPrice = Number(productPrice);

        let item = { productName, productPrice };
        catalogue.push(item);
    }
    let sortedCatalogue = catalogue.sort((a, b) => (a.productName > b.productName) ? 1 : (a.productName < b.productName) ? -1 : 0);

    let group = [];
    let cutCatalogue = [];
    for (const product of sortedCatalogue) {
        let initialLetter = product.productName[0];
        if (!group.some(x => x.initialLetter == initialLetter)) {
            cutCatalogue = sortedCatalogue.filter(x => x.productName[0] == initialLetter);
            group.push({ initialLetter, cutCatalogue });
        };
    }

    for (const el of group) {
        console.log(el.initialLetter);
        for (const obj of el.cutCatalogue) {
            console.log(`  ${obj.productName}: ${obj.productPrice}`);
        }
    }
}

getStorageCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);