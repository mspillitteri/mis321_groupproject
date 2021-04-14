function onLoad() {
    findUserCheckouts();
}

function findUserCheckouts() {
    const userid = localStorage.getItem("userid");
    const url = "https://localhost:5001/API/Checkout";

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        for (i=0; i<json.length; i++) {
            if (json[i].userid == userid) {
                getReturnItems(json[i].userid);
                break;
            }
        }
    });
}

function getReturnItems(checkout) {
    const userid = localStorage.getItem("userid");
    const url = "https://localhost:5001/API/Item";

    writeUserName();

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<ul id=\"list\">";
        json.forEach((item)=>{
            if (item.ischeckedout == true && userid == checkout) {
                html += "<li class=\"flex\"><div class=\"picture\"></div>"; 
                html += "&ensp;" + item.itemname + "&emsp;" + item.itemstatus;
                html += "<button class=\"buttons\">Return</button>";
                html += "</li><p></p>";
            }
        });
        html += "</ul>";
        document.getElementById("items").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function addReturn() {
    const url = "https://localhost:5001/API/Return/" + currentUser;

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