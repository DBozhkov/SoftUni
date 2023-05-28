function solve() {
  let elementToChange = document.getElementById('text').value;
  let typeOfCase = document.getElementById('naming-convention').value;
  let resultString;

  elementToChange = elementToChange.split(' ');

  if (typeOfCase === "Camel Case") {
    resultString = elementToChange.map((elm, i) => i === 0 ? elm.substring(0, 1).toLowerCase() + elm.substring(1).toLowerCase() : elm.substring(0, 1).toUpperCase() + elm.substring(1).toLowerCase());
    resultString = resultString.reduce((acc, elm) => acc += elm);
    
  } else if (typeOfCase === "Pascal Case") {
    resultString = elementToChange.map((elm) => elm.substring(0, 1).toUpperCase() + elm.substring(1).toLowerCase())
    resultString = resultString.reduce((accumulator, elm) => accumulator += elm);
  } else {
    resultString = 'Error!';
  }

  document.getElementById('result').textContent = resultString;
}