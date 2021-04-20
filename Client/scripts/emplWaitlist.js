function getWaitlist(itemid) {
    const url = "https://localhost:5001/API/Waitlist";
    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
       
        let html = "<ul id=\"list\">";
        json.forEach((waitlist)=>{
        if (waitlist.itemid == itemid) {
            html += "<li class=\"flex\"><div class=\"picture\"></div>"; 
            html += "&ensp;" + waitlist.waitlist + "&emsp;" + waitlist.userid + "&emsp;" + waitlist.itemid;
            }
            html += "</li><p></p>";
        });
        html += "</ul>";
        document.getElementById("emplwaitlist").innerHTML = html;
    });
}

function showPopout(itemid){
    console.log(itemid);
    var modal = document.getElementById("editModal");
    document.getElementById("display").value = post;

    modal.style.display = "block";
    var span = document.getElementsByClassName("close")[0];
}

function closePopout()
{
    var modal = document.getElementById("editModal");
    modal.style.display = "none";
}

window.onclick = function(event)
{
    var modal = document.getElementById("editModal");
    if(event.target == modal)
    {
        modal.style.display = "none";
    }
}


