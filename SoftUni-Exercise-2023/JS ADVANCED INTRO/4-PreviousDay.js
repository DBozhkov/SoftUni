function getPreviousDate(year, month, day){
    let input = `${year}-${month}-${day}`;
    let date = new Date(input);
    date.setDate(date.getDate() - 1);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
    
}

getPreviousDate(2016, 9, 30);
getPreviousDate(2015, 5, 10);