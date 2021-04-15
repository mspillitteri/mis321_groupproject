function getItems() {
    const userid = localStorage.getItem("userid");
    const url = "https://localhost:5001/API/Item";

    writeUserName();

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<ul id=\"list\">";
        json.forEach((item)=>{
            var topUser = getTopOfWaitlist(item.itemid);
            var hasWaitlist = waitlistCheck(item.itemid);
            html += "<li class=\"flex\"><div class=\"picture\"></div>"; 
            html += "&ensp;" + item.itemname + "&emsp;" + item.itemstatus;
            if (item.ischeckedout == true) { 
                //show if item is checked out
                html += "<button class=\"buttons\" onclick=\"addWaitlist("+item.itemid+",\'"+userid+"')\">Waitlist</button>";
                html += "&nbsp;";
            }
            else if (userid == topUser && hasWaitlist == true) {
                //show for top of waitlist
                html += "<button class=\"buttons\" onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\">Checkout</button>";
                html += "&nbsp;";
            }
            else if (item.ischeckedout == false && hasWaitlist == false) {
                //show for everyone
                html += "<button class=\"buttons\" onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\">Checkout</button>";
                html += "&nbsp;";
            }
            html += "</li><p></p>";
        });
        html += "</ul>";
        document.getElementById("items").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function addCheckout(currentItem, currentUser) {
    const url = "https://localhost:5001/API/Checkout/" + currentUser;

    fetch(url, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            itemid: currentItem
        })
    })
    .then((response)=>{
        console.log(response);
        getItems();
    })
}

function addWaitlist(currentItem, currentUser) {
    const url = "https://localhost:5001/API/Waitlist/" + currentUser;

    fetch(url, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            itemid: currentItem
        })
    })
    .then((response)=>{
        console.log(response);
        getItems();
    })
}

function writeUserName() {
    const userName = localStorage.getItem("userName");
    let html = "<p>Welcome " + userName + "</p>";
    document.getElementById("welcomeuser").innerHTML = html;
}

function getTopOfWaitlist(itemid) {
    const userid = localStorage.getItem("userid");
    const url = "https://localhost:5001/API/Waitlist/" + itemid;
    var topUser = "";

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        waitlist = json;
        topUser = waitlist[0].userid;
    });
    return topUser;
}

function waitlistCheck(itemid) {
    const url = "https://localhost:5001/API/Waitlist/" + itemid;
    var hasWaitlist = false;

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        waitlist = json;
        if (waitlist != null) {
            hasWaitlist == true;
        }
    });
    return hasWaitlist;
}

// onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\"