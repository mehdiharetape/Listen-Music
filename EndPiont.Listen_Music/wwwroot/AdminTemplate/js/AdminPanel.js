var addSingerBtn = document.getElementById("add-singer-btn");
var listSingerBtn = document.getElementById("list-singer-btn");
var addGenreBtn = document.getElementById("add-genre-btn");
var listGenreBtn = document.getElementById("list-genre-btn");
var addSongBtn = document.getElementById("add-song-btn");
var listSongBtn = document.getElementById("list-song-btn");
var addPlaylistBtn = document.getElementById("add-playlist-btn");
var listPlaylistBtn = document.getElementById("list-playlist-btn");
var addUserBtn = document.getElementById("add-user-btn");
var listUserBtn = document.getElementById("list-user-btn");

var singerAdd = document.getElementById("singer-add");
var singerListContainer = document.getElementById("singer-list-container");
var genreAdd = document.getElementById("genre-add");
var genreListContainer = document.getElementById("genre-list-container");
var songAddContainer = document.getElementById("song-add-container");
var songListContainer = document.getElementById("song-list-container");
var playlistAdd = document.getElementById("playlist-add");
var playlistListContainer = document.getElementById("playlist-list-container");
var userAddContainer = document.getElementById("user-add-container");
var userListContainer = document.getElementById("user-list-container");

/***************************/
function clickOnElements(index) {
    var buttons = [addSingerBtn, listSingerBtn, addGenreBtn, listGenreBtn, 
        addSongBtn, listSongBtn, addPlaylistBtn, listPlaylistBtn,addUserBtn, listUserBtn];

    var elements = [singerAdd, singerListContainer, genreAdd,
        genreListContainer, songAddContainer, songListContainer, playlistAdd, playlistListContainer,
        userAddContainer, userListContainer];

    buttons[index].addEventListener("click", () => {
        elements[index].style.display = 'block';
        for (var i = 0; i < elements.length; i++) {
            if (i == index) {
                continue;
            }
            elements[i].style.display = 'none';
        }
    });
}

function callclickOnElements(index) {
    for (var i = 0; i < index; i++) {
        clickOnElements(i);
    }
}

callclickOnElements(10);