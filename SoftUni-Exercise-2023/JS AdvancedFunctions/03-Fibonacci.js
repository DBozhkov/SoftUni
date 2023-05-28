function getFibonator(){
    let fibFirst = 0;
    let fibSecond = 1;
 
    return function () {
        let currFibFirst = fibFirst;
        let currFibSecond = fibSecond;
 
        fibFirst = currFibSecond;
        fibSecond = currFibFirst + currFibSecond;
 
        return fibFirst;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
