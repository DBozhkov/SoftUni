function validateHttp(obj) {
    let regEx = /^[\w.]+$/;
    let message = String(obj['message']);
    

    if (!obj.hasOwnProperty('method') || obj['method'] !== 'GET' && obj['method'] !== 'POST' && obj['method'] !== 'DELETE' && obj['method'] !== 'CONNECT'){
        throw new Error('Invalid request header: Invalid Method');
    } else if (!obj.hasOwnProperty('uri') || obj['uri'] !== '*' && !obj['uri'].match(regEx)) {
        throw new Error('Invalid request header: Invalid URI');
    } else if (!obj.hasOwnProperty('version') || obj['version'] === '' || obj['version'] !== 'HTTP/0.9' && obj['version'] !== 'HTTP/1.0' && obj['version'] !== 'HTTP/1.1' && obj['version'] !== 'HTTP/2.0') {
        throw new Error('Invalid request header: Invalid Version');
    };

    function containsSpecialChars(str) {
        const specialChars = /[&'"\\<>]/;
        return specialChars.test(str);
    };

    if (!obj.hasOwnProperty('message') || containsSpecialChars(message)) {
        throw new Error('Invalid request header: Invalid Message');
    };

    return obj;
}

validateHttp({
    method: 'POST',
    version: 'HTTP/2.0',
    message: 'rm -rf /*'
});