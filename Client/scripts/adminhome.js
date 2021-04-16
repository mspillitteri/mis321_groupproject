function adminInvReport() {
    window.location.href = "./admininvreport.html";

}

function adminCurrentReport() {
    window.location.href = "./admincurrentreport.html";
}

function writeUserName() {
    const userName = localStorage.getItem("userName");
    let html = "<p>Welcome " + userName + "</p>";
    document.getElementById("welcomeuser").innerHTML = html;
}