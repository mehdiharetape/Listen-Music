const singerBtn = document.getElementById("singer-btn");
const genreBtn = document.getElementById("genre-btn");
const playlistBtn = document.getElementById("playlist-btn");

const singerList = document.getElementById("singer-container");
const genreyList = document.getElementById("genre-cotainer");
const playList = document.getElementById("playlist-container");

singerBtn.addEventListener('mouseenter' , () => {
    singerList.style.display = 'block';
    genreyList.style.display = 'none';
    playList.style.display = 'none';
});
genreBtn.addEventListener('mouseenter' , () => {
    singerList.style.display = 'none';
    genreyList.style.display = 'block';
    playList.style.display = 'none';
});
playlistBtn.addEventListener('mouseenter' , () => {
    singerList.style.display = 'none';
    genreyList.style.display = 'none';
    playList.style.display = 'block';
});

singerList.addEventListener('mouseleave' , () => {
    singerList.style.display = 'none';
});
genreyList.addEventListener('mouseleave' , () => {
    genreyList.style.display = 'none';
});
playList.addEventListener('mouseleave' , () => {
    playList.style.display = 'none';
});
///----------------------------------------------
var usernameButton = document.getElementById("username-button");
var exprof = document.getElementById("exit-prof-container");
usernameButton.addEventListener('click', () => {
    exprof.style.display = 'block';
    exprof.addEventListener('mouseleave', () => {
        exprof.style.display = 'none';
    });
});