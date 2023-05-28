function sortByCriteria(array){
    array.sort((a,b) => a.length - b.length || a.localeCompare(b));
    console.log(array.join('\r\n'));
}

sortByCriteria(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']);
