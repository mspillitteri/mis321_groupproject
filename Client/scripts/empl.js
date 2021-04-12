function getItems() {
    const userid = localStorage.getItem("userid");
    const url = "https://localhost:5001/API/Item";

    fetch(url).then(function(reponse){
        console.log(reponse);
        return reponse.json();
    }).then(function(json){
        let html = "<ul id=\"list\">";
        json.forEach((item)=>{
            html += "<li class=\"flex\"><div class=\"picture\"></div>"; 
            html += "&ensp;" + item.itemname + "&emsp;" + item.itemstatus;
            html += "<button class=\"buttons\" onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\">Checkout</button>";
            html += "&nbsp;"
            html += "<button class=\"buttons\">Return</button>";

            html += "</li>";
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
    })
}

// onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\"