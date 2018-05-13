function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("name", ev.target.getAttribute("name"));
}

function drop(ev) {
    var name = ev.dataTransfer.getData("name");
    var moveCard = document.getElementsByName(name)[0];
    var card = getlastCard(ev.target);

    if ((parseInt(card.id) == parseInt(moveCard.id) + 1 && oppositeColor(card, moveCard)) || isBlank(card, moveCard)) {
        ev.preventDefault();
        card.appendChild(moveCard);
    }
}

function isBlank(card, moveCard) {
    if (card.classList[0] == "stack" && moveCard.id == "13") {
        return true
    }
    return false;
}

function oppositeColor(card, moveCard) {
    if ((card.classList[0] == "D" || card.classList[0] == "H") && (moveCard.classList[0] == "C" || moveCard.classList[0] == "S")) {
        return true;
    }
    else if ((moveCard.classList[0] == "D" || moveCard.classList[0] == "H") && (card.classList[0] == "C" || card.classList[0] == "S")) {
        return true;
    }
    else if (card.classList[0] == "stack1" || card.classList[0] == "stack2" || card.classList[0] == "stack3" || card.classList[0] == "stack4" || card.classList[0] == "stack5" || card.classList[0] == "stack6" || card.classList[0] == "stack7") {
        return true;
    }
    else {
        return false;
    }
}

function pileDrop(ev) {
    var name = ev.dataTransfer.getData("name");
    var card = getlastCard(ev.target);
    var moveCard = document.getElementsByName(name)[0]
    if (document.getElementsByName(name)[0].children.length == 0 && validCard(card, moveCard)) {
        ev.preventDefault();
        ev.target.innerHTML = "";
        ev.target.style.border = "0px";
        card.appendChild(moveCard);
    }
}

function validCard(card, moveCard) {
    if (card.classList[0] == moveCard.classList[0] && parseInt(card.id) == parseInt(moveCard.id) - 1) {
        return true;
    }
    return false;
}

function valueToString(val) {
    var number = parseInt(val);
    if (number == 1) {
        return "A"
    } else if (number == 11) {
        return "J"
    } else if (number == 12) {
        return "Q"
    } else if (number == 13) {
        return "K"
    }
    return val;
}

function newCard(item) {
    $.getJSON('/Games/GetCard/', function (card) {
        var nc = document.getElementById("blankCard").cloneNode(true);
        console.log(card.value);
        console.log(card.suit);
        nc.id = card.value;
        nc.classList.add(card.suit);
        nc.setAttribute("name", card.value.toString() + card.suit);
        nc.innerHTML = valueToString(card.value) + " " + card.suit;
        getlastCard(document.getElementById(item)).appendChild(nc);
    });
}

function startGame() {
    for (i = 0; i < 7; i++) {
        for (j = 1; j < 8 - i; j++) {
            var id = "stack" + j;
            newCard(id);
        }
    }
}

function getlastCard(card) {
    var children = card.children;
    if (children.length == 0) {
        return card;
    } else {
        return getlastCard(children[0]);
    }
}

function deckClick() {
    getlastCard(document.getElementById("pile")).innerHTML = "";
    getlastCard(document.getElementById("pile")).style.border = "0px";
    newCard("pile");
}

function canMove(card) {
    var children = card.children;
    if (children.length == 0) {
        return true;
    } else if (children[0].id == parseInt(card.id) - 1 && oppositeColor(children[0], card)) {
        return canMove(children[0]);
    }
    return false;
}

function setDragabble(ev) {
    if (canMove(ev.target)) {
        ev.target.setAttribute('draggable', true);
    }
    else {
        ev.target.setAttribute('draggable', false);
    }
}