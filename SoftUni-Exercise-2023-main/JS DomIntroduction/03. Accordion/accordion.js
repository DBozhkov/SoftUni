function toggle() {
    let buttonElements = document.getElementsByClassName('button');
    let buttonElement = buttonElements[0];
    let textElement = document.getElementById('extra');

    if (textElement.style.display == 'none' || textElement.style.display == '') {
        textElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else if (textElement.style.display == 'block') {
        textElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}