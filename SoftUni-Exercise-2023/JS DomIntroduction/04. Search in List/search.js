function search() {
   let towns = document.querySelectorAll("li");
   let matchCounter = 0;
   let searchElement = document.getElementById('searchText').value;
   let resultElement = document.getElementById('result');

   for (const el of towns) {
      if(el.textContent.includes(searchElement)){
         el.style.fontWeight = 'bold';
         el.style.textDecoration = 'underline';
         matchCounter++;
      };
   };

   resultElement.textContent = `${matchCounter} matches found`;
}
