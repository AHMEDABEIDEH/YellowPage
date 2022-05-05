const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const containerS = document.getElementById('containerS');

signUpButton.addEventListener('click', () => {
	containerS.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
	containerS.classList.remove("right-panel-active");
});