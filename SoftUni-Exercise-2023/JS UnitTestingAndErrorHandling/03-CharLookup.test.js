const lookupChar = require('./03-CharLookup');
const assert = require('chai').assert;

describe('lookupChar function unit testing', () => {
    it('Should return undefined if parameters are not string and number', () => {
        assert.strictEqual(lookupChar({}, []), undefined);
        assert.strictEqual(lookupChar(23, 'boom'), undefined);
        assert.strictEqual(lookupChar(30, 30), undefined);
        assert.strictEqual(lookupChar('test', 'test'), undefined);
        assert.strictEqual(lookupChar({}, 3), undefined);
        assert.strictEqual(lookupChar('test', 3.5), undefined);
    })
    it('Should return incorrect index if input is valid but index is out of bounds', () => {
        assert.strictEqual(lookupChar('Mitko', -3), 'Incorrect index');
        assert.strictEqual(lookupChar('Mitko', 7), 'Incorrect index');
        assert.strictEqual(lookupChar('Mitko', 11), 'Incorrect index');
        
    })
    it('Should return char at index if inputs are valid', () => {
        assert.strictEqual(lookupChar('Mitko', 1), 'i');
        assert.strictEqual(lookupChar('Mitko', 2), 't');
        assert.strictEqual(lookupChar('Mitko', 0), 'M');
    })
})