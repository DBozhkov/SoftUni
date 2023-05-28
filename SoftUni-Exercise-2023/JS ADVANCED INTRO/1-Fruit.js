function printFruitPrice(name, gramsWeight,pricePerKg){
    let fruitName = name;
    let weight = gramsWeight;
    let priceKg = pricePerKg;
    console.log(`I need $${(weight / 1000 * priceKg).toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${fruitName}.`);
}

printFruitPrice('orange', 2500, 1.80);
