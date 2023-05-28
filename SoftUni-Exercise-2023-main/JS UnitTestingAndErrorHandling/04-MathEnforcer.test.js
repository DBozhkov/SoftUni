const mathEnforcer = require('./04-MathEnforcer');
const {assert} = require('chai');

describe('Test mathEnforcer object functionality', () => {
    describe('addFive function unit testing', () => {
        it('Should return undefined if input is not a number', () => {
            assert.equal(mathEnforcer.addFive('test'), undefined);
        });
        it('Should add 5 to a number if input is valid', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(-4), 1);
            assert.equal(mathEnforcer.addFive(3.5), 8.5);
        });
        it('Result should be in range within 0.01', () => {
            assert.closeTo(mathEnforcer.addFive(1.1), 6.1, 0.01);
            assert.closeTo(mathEnforcer.addFive(1), 6, 0.01);
        });
    });
    describe('subtractTen function unit testing', () => {
        it('Should return undefined if input is not a number', () => {
            assert.equal(mathEnforcer.subtractTen('string'), undefined);
        });
        it('Should subtract 10 to a number if input is valid', () => {
            assert.equal(mathEnforcer.subtractTen(11), 1);
            assert.equal(mathEnforcer.subtractTen(-10), -20);
            assert.equal(mathEnforcer.addFive(-10.5), -20.5);
        });
        it('Result should be in range within 0.01', () => {
            assert.closeTo(mathEnforcer.subtractTen(11), 1, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(-10), -20, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(-10.5), -20.5, 0.01);
        });
    });
    describe('sum function unit testing', () => {
        it('Should return undefined if one of the inputs is not a number', () => {
            assert.equal(mathEnforcer.sum('string', 10), undefined);
            assert.equal(mathEnforcer.sum(1, 'test'), undefined);
            assert.equal(mathEnforcer.sum('string', 'string'), undefined);
            assert.equal(mathEnforcer.sum('string', -1), undefined);
        });
        it('Should return sum of both numbers if inputs are valid', () => {
            assert.equal(mathEnforcer.sum(2, 3), 5);
            assert.equal(mathEnforcer.sum(-10, 11), 1);
            assert.equal(mathEnforcer.sum(-10, -11), -21);
            assert.equal(mathEnforcer.sum(2.5, 2.5), 5);
            assert.equal(mathEnforcer.sum(-2.5, -2.5), -5);
        });
        it('Result should be in range within 0.01', () => {
            assert.closeTo(mathEnforcer.sum(1, 1), 2, 0.01);
            assert.closeTo(mathEnforcer.sum(-3, -2), -5, 0.01);
            assert.closeTo(mathEnforcer.sum(-3.5, -2.5), -6, 0.01);
        });
    });
})