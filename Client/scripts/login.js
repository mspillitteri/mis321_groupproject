function getUsers() {
    const url = "https://localhost:5001/API/User";

    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        users = json;
        login(users);
    });
}

function login(users) {
    const loginInfo = document.getElementById("logintext").value;
    users.forEach(user =>{
        if (loginInfo == user.email && user.isadmin == true) {
            localStorage.setItem("userid", user.userid);
            localStorage.setItem("userName", user.userfname + " " + user.userlname);
            localStorage.setItem("userstatus", user.userstatus);
            window.location.href = "./adminhome.html";
        }
        else if (loginInfo == user.email) {
            localStorage.setItem("userid", user.userid);
            localStorage.setItem("userName", user.userfname + " " + user.userlname);
            localStorage.setItem("userstatus", user.userstatus);
            window.location.href = "./emplhome.html";
        }
    });
}

// function getItems() {
//     const userid = localStorage.getItem("userid");
//     const url = "https://localhost:5001/API/Item";

//     fetch(url).then(function(reponse){
//         console.log(reponse);
//         return reponse.json();
//     }).then(function(json){
//         let html = "<ul id=\"list\">";
//         json.forEach((item)=>{
//             html += "<li class=\"flex\"><div class=\"picture\"></div>"; 
//             html += "&ensp;" + item.itemname + "&emsp;" + item.itemstatus;
//             html += "<button class=\"buttons\" onclick=\"addCheckout("+item.itemid+",\'"+userid+"')\">Checkout</button>";
//             html += "&nbsp;"
//             html += "<button class=\"buttons\">Return</button>";
//             html += "</li>";
//         });
//         html += "</ul>";
//         document.getElementById("items").innerHTML = html;
//     }).catch(function(error){
//         console.log(error);
//     });
// }