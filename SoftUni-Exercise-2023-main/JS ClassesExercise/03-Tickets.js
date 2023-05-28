function returnTicketsArray(array, sortElement){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        };
    }
    let resultArr = [];
    for (const el of array) {
        let elArray = el.split('|');
        let destinationName = elArray[0];
        let price = Number(elArray[1]);
        let status = elArray[2];
        let ticket = new Ticket(destinationName, price, status);
        resultArr.push(ticket);
    };
    let sorted = resultArr.sort(((a, b) => (a[sortElement] > b[sortElement]) ? 1 : (a[sortElement] < b[sortElement]) ? -1 : 0));
    return sorted;
}

console.log(returnTicketsArray(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));