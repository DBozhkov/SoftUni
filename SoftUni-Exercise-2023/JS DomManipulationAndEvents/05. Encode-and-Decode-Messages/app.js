function encodeAndDecodeMessages() {
    let textAreaElements = Array.from(document.querySelectorAll('div textarea'));
    let buttonElements = Array.from(document.querySelectorAll('button'));
    buttonElements[0].addEventListener('click', encode);
    buttonElements[1].addEventListener('click', decode);

    function encode(){
        let encodeInput = textAreaElements[0].value.split('');
        function incrementChar(char) {
            return String.fromCharCode(char.charCodeAt(0) + 1)
        };
        let result = '';
        for (const el of encodeInput) {
            result += incrementChar(el);
        };
        textAreaElements[1].value = result;
        textAreaElements[0].value = '';
    };

    function decode(){
        let decodeInput = textAreaElements[1].value.split('');
        function decrementChar(char) {
            return String.fromCharCode(char.charCodeAt(0) - 1)
        };
        let result = '';
        for (const el of decodeInput) {
            result += decrementChar(el);
        };
        textAreaElements[1].value = result;
    };
}
