class Hex {
    constructor(value) {
        this.number = Number(value);
    }

    valueOf() {
        return this.number;
    }

    toString() {
        return '0x' + this.number.toString(16).toUpperCase();
    }

    plus(input) {
        if (typeof(input) === 'number') {
            return new Hex(this.number + input);
        } else if (typeof(input) === 'object') {
            return new Hex(this.number + input.valueOf());
        } else {
            throw new Error('Input is not a number or Hex object!');
        }
    }

    minus(input) {
        if (typeof(input) === 'number') {
            return new Hex(this.number - input);
        } else if (typeof(input) === 'object') {
            return new Hex(this.number - input.valueOf());
        } else {
            throw new Error('Input is not a number or Hex object!');
        }
    }

    parse(inputString) {
        return parseInt(inputString, 16);
    }
}