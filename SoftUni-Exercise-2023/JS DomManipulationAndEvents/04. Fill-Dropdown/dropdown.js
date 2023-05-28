function addItem() {
    let textInputElement = document.getElementById('newItemText').value;
    let valueInputElement = document.getElementById('newItemValue').value;
    let button = document.querySelector('input[type="button"]');


    let option = document.createElement('option');
    let menu = document.getElementById('menu');
    option.innerText = textInputElement;
    option.value = valueInputElement;
    menu.appendChild(option);

    document.querySelector('input#newItemText').value = '';
    document.querySelector('input#newItemValue').value = '';
};