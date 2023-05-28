function validate() {    
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', () => {
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        if (!inputElement.value.match(regex)) {
            inputElement.classList.add("error");
        } else{
            inputElement.classList.remove('error');
        }
    });
}