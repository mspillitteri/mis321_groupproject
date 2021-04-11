function login() {
    const url = "https://localhost:5001/API/User";
    const loginInfo = document.getElementById("logintext").value;
    
    fetch(url).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        users = json;
        checkUsername(users, loginInfo);
    })
}

function checkUsername(users, loginInfo) {
    users.forEach(user => {
        if (loginInfo == user.email) {
            window.location.replace("google.com");
            console.log(loginInfo);
        }
        else {
            console.log("error");
        }
    });
}