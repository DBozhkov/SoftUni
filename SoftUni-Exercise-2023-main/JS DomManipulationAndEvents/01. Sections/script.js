function create(words) {
   let contentElement = document.getElementById('content');

   for(let i = 0; i < words.length; i++){
      let divElement = contentElement.appendChild(document.createElement('div'));
      divElement.appendChild(document.createElement('p'));
   };

   let paragraphs = document.getElementsByTagName('p');
   counter = 0;
   let divElements = [];

   for (const el of paragraphs) {
      divElements.push(el.parentNode);
      el.textContent = words[counter];
      el.style.display = 'none';
      counter++;
   };

   divElements.forEach(x => x.addEventListener('click', () => x.firstChild.style.display = 'block'));
}