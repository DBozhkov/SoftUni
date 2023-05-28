function add(num) {
    let sum = 0;

    function inside(numb){
        sum += numb;
        return inside;
    }
    inside.toString = () => {
        return sum;
    };

    return inside(num);
  }

  console.log((add(1)(6)(-3)).toString());
