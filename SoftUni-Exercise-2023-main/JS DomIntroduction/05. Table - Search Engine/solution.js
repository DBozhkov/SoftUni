function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tableElements = Array.from(document.querySelectorAll('table tbody tr'));
      let searchElement = document.getElementById('searchField').value;

      tableElements.map(row => row.classList.remove('select'));
      for (const row of tableElements) {
         let rowData = row.innerText.split('\t');

         for (const item of rowData) {
            if (item.toLowerCase().includes(searchElement.toLowerCase())) {
               row.classList.add('select');
            }
         }
      }
   }
}