'use strict';

function solve() {
    let generateID = (function () {
        let id = 0;
        return function () {
            ++id;
            return id;
        };
    })();

    const VALIDATION = {
        validateStrings: function (input) {
            if (typeof input !== 'string' || input.length < 3 || input > 25) {
                throw new Error('Provided string is not valid');
            }
        }
    };

    class Player {
        constructor(name) {
            this.name = name;
            this._allPlaylists = []
        }

        get allPlaylists() {
            return this._allPlaylists;
        }
        set name(value) {
            VALIDATION.validateStrings(value);
            this._name = value;
        }
        get name() {
            return this._name;
        }

        addPlaylist(playlistToAdd) {

            if (!(playlistToAdd instanceof PlayList)) {
                throw new Error('bro, this is not a playlist');
            }

            this.allPlaylists.push(playlistToAdd);

            return this;
        }

        getPlaylistById(id) {

            return this.allPlaylists.find(x => x.id === id) || null;

        }

        removePlaylist(query) {

            let indexToRemove = 0;

            if (typeof query === 'object') {
                indexToRemove = this.allPlaylists.findIndex(x => x.id === query.id);
            } else {
                indexToRemove = this.allPlaylists.findIndex(x => x.id === query);
            }
            if (indexToRemove < 0) {
                throw new Error('playlist not found in the current player');
            }

            this.allPlaylists.splice(indexToRemove, 1);

            return this;
        }

        listPlaylists(page, size) {
            if ((page * size) > this.allPlaylists.length || page < 0 || size <= 0) {
                throw new Error('Cannot list playlists like that');
            }

            let startId = page * size,
                endId = ((page + 1) * size) - 1;

            let sortedArray = this.allPlaylists.slice().sort(function (x, y) {
                if (x.title === y.title) {
                    return x.id - y.id;
                } else {
                    if (x.title > y.title) {
                        return 1;
                    } else if (x.title < y.title) {
                        return -1;
                    } else {
                        return 0;
                    }
                }
            });
            return sortedArray.filter(x => x.id >= startId && x.id <= endId);
        }


        contains(playable, playlist) {

            let result = this.allPlaylists.find(x => x.id === playlist.id).allPlayable.findIndex(x => x.id === playable.id);
            if(result >= 0){
                return true;
            } else{
                return false;
            }
        }

        search(pattern) {
            return this.allPlaylists.filter(function(x){
                if(x.allPlayable.find(x => x.title.indexOf(pattern) >= 0) === undefined){
                    return false
                } else{
                    return true;
                }
            });
        }
    }

    class PlayList {
        constructor(name) {
            this._id = generateID();
            this.name = name;
            this._allPlayable = [];
        }

        get id() {
            return this._id;
        }
        get allPlayable() {
            return this._allPlayable;
        }

        set name(value) {
            VALIDATION.validateStrings(value);
            this._name = value;
        }
        get name() {
            return this._name;
        }

        addPlayable(playable) {
            this.allPlayable.push(playable);
            return this;
        }

        getPlayableById(idToFind) {
            return this.allPlayable.find(x => x.id === idToFind) || null;
        }

        removePlayable(query) {

            let indexToRemove = 0;
            if (typeof query === `object`) {
                indexToRemove = this.allPlayable.findIndex(x => x.id === query.id);
            } else {
                indexToRemove = this.allPlayable.findIndex(x => x.id === query);
            }

            if (indexToRemove < 0) {
                throw new Error(`Playable not found in the playlist`);
            }
            this.allPlayable.splice(indexToRemove, 1);
            return this;
        }

        listPlayables(page, size) {
            if ((page * size) > this.allPlayable.length || page < 0 || size <= 0) {
                throw new Error('Cannot list playables like that');
            }

            let startId = page * size,
                endId = ((page + 1) * size) - 1;

            let sortedArray = this.allPlayable.slice().sort(function (x, y) {
                if (x.title === y.title) {
                    return x.id - y.id;
                } else {
                    if (x.title > y.title) {
                        return 1;
                    } else if (x.title < y.title) {
                        return -1;
                    } else {
                        return 0;
                    }
                }
            });
            return sortedArray.filter(x => x.id >= startId && x.id <= endId);
        }
    }

    class Playable {
        constructor(title, author) {
            this._id = generateID();
            this.title = title;
            this.author = author;
        }

        get id() {
            return this._id;
        }

        set title(value) {
            VALIDATION.validateStrings(value);
            this._title = value;
        }
        get title() {
            return this._title;
        }

        set author(value) {
            VALIDATION.validateStrings(value);
            this._author = value;
        }
        get author() {
            return this._author;
        }

        play() {

            return `${this.id}. ${this.title} - ${this.author}`;

        }


    }

    class Audio extends Playable {

        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }
        set length(value) {

            this._length = value;
        }
        get length() {
            return this._length;
        }

        play() {
            return super.play() + ` - ${this.length}`;
        }

    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }
        set imdbRating(value) {

            this._imdbRating = value;
        }
        get imdbRating() {
            return this._imdbRating;
        }
        play() {
            return super.play() + ` - ${this.imdbRating}`;
        }
    }


    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new PlayList(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

let audioPlayer = solve();

console.log(`==== TEST AUDIO INITIATION ====`);
let myAudio = audioPlayer.getAudio('some Audio Title check', 'someAudioAuthor', 15);
let myAudioTwo = audioPlayer.getAudio('some Audio Title Two', 'someAudioAuthorTwo', 13);
console.log(myAudio.play());

console.log(`==== TEST VIDEO INITIATION ====`);
let myVideo = audioPlayer.getVideo('some Video Title', 'someVideoAuthor', 8.4);
console.log(myVideo.play());

console.log(`==== TEST ADD PLAYABLE ====`);

let myPlaylist = audioPlayer.getPlaylist('playlistName');
myPlaylist.addPlayable(myAudio).addPlayable(myVideo).addPlayable(myAudioTwo);
console.log(myPlaylist);

console.log(`==== TEST GET PLAYABLE BY ID ====`);

console.log(myPlaylist.getPlayableById(2));

console.log(`==== TEST REMOVE PLAYABLE BY ID ====`);

myPlaylist.removePlayable(1);
console.log(myPlaylist);

console.log(`==== TEST REMOVE PLAYABLE BY PLAYABLE ====`);
myPlaylist.removePlayable(myVideo);
console.log(myPlaylist);

console.log(`==== RESET PLAYLIST AFTER REMOVE TESTS ====`);
myPlaylist.addPlayable(myAudio).addPlayable(myVideo);
console.log(myPlaylist);

console.log(`==== TEST LIST PLAYABLES ====`);

console.log(myPlaylist.listPlayables(1, 2));

console.log(`==== TEST PLAYER ADD PLAYLIST ====`);

let myPlayer = audioPlayer.getPlayer('playerName');
myPlayer.addPlaylist(myPlaylist);
console.log(myPlayer.allPlaylists);

console.log(`==== TEST PLAYER CONTAINS ====`);
let myVideoTwo = audioPlayer.getVideo('some Video Title Two', 'someVideoAuthor', 8.4);
console.log(myPlayer.contains(myVideoTwo, myPlaylist));
console.log(myPlayer.contains(myVideo, myPlaylist));

console.log(`==== TEST PLAYER SEARCH ====`);

console.log(myPlayer.search('check'));
console.log(myPlayer.search('checkk'));