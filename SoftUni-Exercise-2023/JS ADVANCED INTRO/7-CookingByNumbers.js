function solve(num, com1, com2, com3, com4, com5) {
    let number = +num;
 
    let arr = [com1, com2, com3, com4, com5];
    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number++; break;
            case 'bake': number *= 3; break;
            case 'fillet': number -= number * 0.2; break;
        }
        console.log(number);
    }
}