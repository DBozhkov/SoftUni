function getLowestPrice(array){
    let products = [];

    for (const el of array) {
        let [townName, productName, productPrice] = el.split(' | ');
        productPrice = Number(productPrice);

        if(products.filter(x => x.productName == productName).length > 0){
            let product = products.find(x => x.productName == productName);

            if(product.productPrice > productPrice){
                product.productPrice = productPrice;
                product.townName = townName;
            }
        }else{
            let product = {productName, townName, productPrice};
            products.push(product);
        }
    }

    for (let prod of products) {
        console.log(`${prod.productName} -> ${prod.productPrice} (${prod.townName})`);
    }
}


getLowestPrice(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);
