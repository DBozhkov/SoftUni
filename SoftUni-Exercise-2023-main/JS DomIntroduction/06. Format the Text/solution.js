function solve() {
  let textElement = document.getElementById('input').value;
  let sentences = textElement.split('.').filter(x => x !== '');
  let resultElement = document.getElementById('output');
  
  while(sentences.length > 0){
    let paragraph = document.createElement('p');
    let splitted = sentences.splice(0, 3).join('. ');
    paragraph.textContent += splitted + '.';
    resultElement.appendChild(paragraph);
  };  
}