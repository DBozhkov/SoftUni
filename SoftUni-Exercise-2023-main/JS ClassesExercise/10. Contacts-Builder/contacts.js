class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }

    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;

        if (this.titleDiv) {
           this.titleDiv.className = this._online ? 'title online' : 'title';
        }
    }
    render(id) {
        let elementToAppendTo = document.getElementById(id);

        if (elementToAppendTo.firstElementChild !== null && elementToAppendTo.firstElementChild.innerText.includes('firstName')) {
            elementToAppendTo.firstElementChild.remove();
        }
        //Creating elements
        this.article = document.createElement('article');
        this.titleDiv = document.createElement('div');
        this.infoDiv = document.createElement('div');
        this.infoButton = document.createElement('button');
        this.phoneSpan = document.createElement('span');
        this.emailSpan = document.createElement('span');

        //Appending elements and setting values and events
        this.titleDiv.textContent = this.firstName + ' ' + this.lastName;
        this.infoButton.innerHTML = `<span>&#8505;</span>`;

        
        this.infoDiv.classList.add('info');
        this.infoDiv.style.display = 'none';
        this.phoneSpan.innerHTML = `&phone; ${this.phone}`;
        
        this.emailSpan.innerHTML = `&#9993; ${this.email}`;
        this.titleDiv.className = this.online ? 'title online' : 'title';
        
        this.titleDiv.appendChild(this.infoButton);
        
        this.infoDiv.appendChild(this.phoneSpan);
        this.infoDiv.appendChild(this.emailSpan);
        
        this.article.appendChild(this.titleDiv);
        this.article.appendChild(this.infoDiv);
        
        elementToAppendTo.appendChild(this.article);
        
        this.infoButton.addEventListener('click', toggleInfo.bind(this));

        function toggleInfo(e) {
            if (this.infoDiv.style.display === 'block') {
                this.infoDiv.style.display = 'none';
            } else {
                this.infoDiv.style.display = 'block';
            }
        }
    }
}


