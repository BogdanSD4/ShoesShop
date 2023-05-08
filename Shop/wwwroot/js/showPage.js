
const cartIcon = document.querySelector('.cart-icon');
const cartPanel = document.querySelector('.cart-panel');

const methods = {
    method1: () => {
        cartPanel.style.right = '0px';
        cartPanel.style.display = 'block';

        cartIcon.classList.remove('cart-open')
        cartIcon.classList.add('cart-close')
    },
    method2: () => {
        cartPanel.style.right = '-450px';
        cartPanel.style.display = 'none';

        cartIcon.classList.add('cart-open')
        cartIcon.classList.remove('cart-close')
    }
};

function toggleMethods(event) {
    event.preventDefault();
    const currentMethod = toggleMethods.currentMethod || 'method1';
    methods[currentMethod]();
    toggleMethods.currentMethod = currentMethod === 'method1' ? 'method2' : 'method1';
}

cartIcon.addEventListener('click', toggleMethods);