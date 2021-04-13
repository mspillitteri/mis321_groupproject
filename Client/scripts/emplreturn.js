
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