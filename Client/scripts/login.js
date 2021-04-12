function login(users) {
    const loginInfo = document.getElementById("logintext").value;
    users.forEach(user =>{
        if (loginInfo == user.email) {
            console.log(loginInfo);
            window.location.href = "./empl.html";
        }
    });
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