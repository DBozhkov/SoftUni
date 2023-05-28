class List{
    constructor(){
        this.list = [];
        this.size = this.list.length;
    };

    add(input){
        this.list.push(Number(input));
        this.list.sort((a, b) => a - b);
        this.size = this.list.length;
    };
    remove(index){
        if(index > this.list.length || index < 0){
            return;
        } else{
            this.list.splice(index, 1);
        };
        this.size = this.list.length;
    };
    get(index){
        if(index > this.list.length || index < 0){
            return;
        } else{
            return this.list[index];
        };
    };
}

let list = new List();
list.add(5);
list.add(3);
list.remove(0);
console.log(list.size);