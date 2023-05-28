function returnRectangle(width, height, color) {
    let rectangle = { width, height, color };
    
    function capitalizeFirstLetter(input) {
        return input.charAt(0).toUpperCase() + input.slice(1);
    }
    rectangle.color = capitalizeFirstLetter(color);

    rectangle.calcArea = () => width * height;

    return rectangle;
}


let rect = returnRectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

