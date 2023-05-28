function subtract() {
    let firstNum = document.getElementById('firstNumber').value;
    let secondNum = document.getElementById('secondNumber').value;

    let subtractedNum = Number(firstNum) - Number(secondNum);

    let resultElement = document.getElementById('result');
    resultElement.innerText = subtractedNum;
}