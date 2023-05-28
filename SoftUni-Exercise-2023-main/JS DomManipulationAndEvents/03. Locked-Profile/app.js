function lockedProfile() {
    let btnElements = Array.from(document.querySelectorAll('button'));

    for (const btn of btnElements) {
        btn.addEventListener('click', showInformation);
    };

    function showInformation(e) {
        let currTarget = e.target.parentElement.querySelector('div');
        currTarget = currTarget.querySelectorAll('input[type="email"]');

        let isChecked = e.target.parentElement.querySelector('input[value="unlock"]').checked;
        console.log(isChecked);
        if (isChecked) {
            if (e.target.textContent === 'Show more') {
                for (const el of currTarget) {
                    el.parentNode.style.display = 'block';
                };
                e.target.textContent = 'Hide it';
            } else if (e.target.textContent === 'Hide it') {
                for (const el of currTarget) {
                    el.parentNode.style.display = 'none';
                };
                e.target.textContent = 'Show more';
            };
        };
    };
};