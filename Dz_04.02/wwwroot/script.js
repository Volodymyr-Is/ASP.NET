async function login() {
    const response = await fetch('/api/auth/token', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ login: document.getElementById('login').value, password: document.getElementById('password').value })
    });
    const data = await response.json();
    localStorage.setItem('token', data.access_token);
}

async function loadProducts() {
    const response = await fetch('/api/product', {
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') }
    });
    const products = await response.json();
    document.getElementById('productList').innerHTML = products.map(p => `<li>${p.name} - $${p.price}</li>`).join('');
}
