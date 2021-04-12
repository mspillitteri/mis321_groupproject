function login(users) {
    const loginInfo = document.getElementById("logintext").value;
    users.forEach(user =>{
        console.log(user.userid);
        if (loginInfo == user.email && user.isadmin == true) {
            localStorage.setItem("userid", user.userid);
            window.location.href = "./admin.html";
        }
        else if (loginInfo == user.email) {
            localStorage.setItem("userid", user.userid);
            window.location.href = "./empl.html";
        }
    });
    console.log("Invalid login");
}

function getUsers() {
    const url = "https://localhost:5001/API/User";

    fetch(url).then(function(reponse){
        console.log(reponse);
        return reponse.json();
    }).then(function(json){
        console.log(json);
        users = json;
        login(users);
    });
}

function getItems() {
    const userid = localStorage.getItem("userid");
    console.log(userid);
    const url = "https://localhost:5001/API/Item";
    //const url2 = "https://localhost:5001/API/User";

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