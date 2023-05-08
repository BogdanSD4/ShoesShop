
const products = document.querySelectorAll('.product');
products.forEach((product) => {

    const slides = product.querySelectorAll('.slide');
    const prev = document.querySelector('.prev');
    const next = document.querySelector('.next');
    let currentSlide = 0;

    slides[currentSlide].classList.add('active');

    prev.addEventListener('click', () => {
        showSlide(currentSlide - 1, slides);
    });

    next.addEventListener('click', () => {
        showSlide(currentSlide + 1, slides);
    });

    function showSlide(n, slides) {
        slides[currentSlide].classList.remove('active');
        currentSlide = (n + slides.length) % slides.length;
        slides[currentSlide].classList.add('active');
    } 
});

function addToCart(product) {
    
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../Product/AddProduct", true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            $('#replace-items').load('../Product/GetShopCart');
        }
    };
    xhr.send(JSON.stringify(product));
}









