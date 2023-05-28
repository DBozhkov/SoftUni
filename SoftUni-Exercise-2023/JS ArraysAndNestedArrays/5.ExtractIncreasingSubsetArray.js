function extractSubsetIncreasing(array){
    let biggestNum = Number.NEGATIVE_INFINITY;
    function sequense(x) {
        if (biggestNum <= x){
            biggestNum = x;
            return true;
        }else   {
            return false;
        }
    }
    let result = array.filter(x => sequense(x));

    return result;
};
