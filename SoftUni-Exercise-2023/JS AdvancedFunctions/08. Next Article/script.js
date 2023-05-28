function getArticleGenerator(articles) {
    let arr = articles;

    return function(){
        if(arr.length == 0){
            return;
        }
        let divElement = document.getElementById('content');
        let articleElement = document.createElement('article');
        articleElement.textContent = arr.splice(0, 1);

        divElement.appendChild(articleElement);
    }
}
