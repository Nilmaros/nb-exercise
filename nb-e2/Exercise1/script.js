function replaceLetterWithPosition(str) {
    var alphabet = "abcdefghijklmnopqrstuvwxyz";
    document.getElementById("result").innerHTML = "";
    [...str.replace(/[^a-z]+/gi, '')].forEach(letter => {
        document.getElementById("result").innerHTML += alphabet.indexOf(letter.toLowerCase()) + 1 + " ";
    })
};