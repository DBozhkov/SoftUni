const isOddOrEven = require('./02-EvenOrOdd');
const assert = require('chai').assert;

describe('Check Odd or Even functionality', () => {
    it('Should return undefined if input is a number', () =>{
        assert.equal(isOddOrEven(3), undefined);
    });
    it('Should return undefined if input is an object', () =>{
        assert.equal(isOddOrEven({}), undefined);
    });
    it('Should return undefined if input is an array', () =>{
        assert.equal(isOddOrEven([]), undefined);
    });
    it('Should return undefined if input is undefined', () =>{
        assert.equal(isOddOrEven(undefined), undefined);
    });
    it('Should return correct value if input is correct', () =>{
        assert.equal(isOddOrEven('even'), 'even');
        assert.equal(isOddOrEven('odd'), 'odd');
    });
    it('Should work correctly if input is multiple strings',() =>{
        assert.equal(isOddOrEven('even even '), 'even');
        assert.equal(isOddOrEven('odd odd'), 'odd');
    });
})