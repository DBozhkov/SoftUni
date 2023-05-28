function calculator() {
    let firstInput;
    let secondInput;
    let resultInput;
    function init(selector1, selector2, resultSelector){
        firstInput = document.querySelector(selector1);
        secondInput = document.querySelector(selector2);
        resultInput = document.querySelector(resultSelector);
    }

    function add(){
        resultInput.value = Number(firstInput.value) + Number(secondInput.value);
    }

    function subtract(){
        resultInput.value = Number(firstInput.value) - Number(secondInput.value);
    }
    return {
        init,
        add,
        subtract
    }
}




