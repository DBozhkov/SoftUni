window.addEventListener("load", solve);

function solve() {
  let firstNameElement = document.getElementById('first-name');
  let lastNameElement = document.getElementById('last-name');
  let ageElement = document.getElementById('age');
  let titleElement = document.getElementById('story-title');
  let genreElement = document.getElementById('genre');
  let storyElement = document.getElementById('story');
  let publishButtonElement = document.getElementById('form-btn');
  let previewDivElement = document.getElementById('preview-list');
  

  publishButtonElement.addEventListener('click', (e) => {
    e.preventDefault();
    if (firstNameElement.value !== '' && lastNameElement.value !== '' && ageElement.value !== '' && titleElement.value !== '' && genreElement.value !== '' && storyElement.value !== ''){
    let storyClassElement = document.createElement('li');
    storyClassElement.classList.add('story-info');
    let articleElement = document.createElement('article');

    let nameh4Element = document.createElement('h4');
    let agePElement = document.createElement('p');
    let titlePElement = document.createElement('p');
    let genrePElement = document.createElement('p');
    let storyPElement = document.createElement('p');
    let saveButtonElement = document.createElement('button');
    let editButtonElement = document.createElement('button');
    let deleteButtonElement = document.createElement('button');
    
    nameh4Element.innerText = `Name: ${firstNameElement.value} ${lastNameElement.value}`;
    agePElement.innerText = `Age: ${Number(ageElement.value)}`;
    titlePElement.innerText = `Title: ${titleElement.value}`;
    genrePElement.innerText = `Genre: ${genreElement.value}`;
    storyPElement.innerText = storyElement.value;
    saveButtonElement.classList.add('save-btn');
    saveButtonElement.textContent = 'Save Story';
    editButtonElement.classList.add('edit-btn');
    editButtonElement.textContent = 'Edit Story';
    deleteButtonElement.classList.add('delete-btn');
    deleteButtonElement.textContent = 'Delete Story';

    articleElement.appendChild(nameh4Element);
    articleElement.appendChild(agePElement);
    articleElement.appendChild(titlePElement);
    articleElement.appendChild(genrePElement);
    articleElement.appendChild(storyPElement);
    storyClassElement.appendChild(articleElement);
    storyClassElement.appendChild(saveButtonElement);
    storyClassElement.appendChild(editButtonElement);
    storyClassElement.appendChild(deleteButtonElement);
    previewDivElement.appendChild(storyClassElement);

    firstNameElement.value = '';
    lastNameElement.value = '';
    ageElement.value = '';
    titleElement.value = '';
    genreElement.value = '';
    storyElement.value = '';

    publishButtonElement.disabled = true;

    editButtonElement.addEventListener('click', (e) => {
      let previewArticleElement = e.currentTarget.parentElement.getElementsByTagName('article')[0];

      firstNameElement.value = previewArticleElement.children[0].textContent.replace('Name: ', '').split(' ')[0];
      lastNameElement.value = previewArticleElement.children[0].textContent.replace('Name: ', '').split(' ')[1];
      ageElement.value = previewArticleElement.children[1].textContent.replace('Age: ', '');
      titleElement.value = previewArticleElement.children[2].textContent.replace('Title: ', '');
      genreElement.value = previewArticleElement.children[3].textContent.replace('Genre: ', '');
      storyElement.value = previewArticleElement.children[4].textContent;
  
      e.currentTarget.parentElement.remove();
  
      publishButtonElement.disabled = false;
    });
    
    saveButtonElement.addEventListener('click', (e) => {
      document.getElementById('main').innerHTML = '';
      let h1 = document.createElement('h1');
      h1.textContent = 'Your scary story is saved!';
      document.getElementById('main').appendChild(h1);
    });

    deleteButtonElement.addEventListener('click', (e) => {
      e.currentTarget.parentElement.remove();
      publishButtonElement.disabled = false;
    })
    }
  })
}
