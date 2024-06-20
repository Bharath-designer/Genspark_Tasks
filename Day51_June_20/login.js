document.getElementById('login-form').addEventListener('submit', function(event) {
    event.preventDefault();

    const users = [
        { username: 'user1', password: 'pass1' },
        { username: 'user2', password: 'pass2' },
        { username: 'user3', password: 'pass3' }
    ];

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const loginMessage = document.getElementById('login-message');

    const user = users.find(user => user.username === username && user.password === password);

    if (user) {
        loginMessage.textContent = 'Login successful!';
        loginMessage.style.color = 'green';
    } else {
        loginMessage.textContent = 'Invalid username or password.';
        loginMessage.style.color = 'red';
    }
});
