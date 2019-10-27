function create() {
    document.getElementById('create').addEventListener('submit', create);
    const phoneNo = document.getElementById('phoneNo').value;
    const distKey = document.getElementById('distKey');
    const pending = document.getElementById('pending');
    const key = document.getElementById('key');

    if (distKey.style.display === "none") {
        distKey.style.display = "block";
        pending.style.display = "none";
    }

    event.preventDefault();

    fetch('/api/group', {
        method: 'POST',
        headers: {"content-type": "application/json"},
        body: JSON.stringify({phoneNumber: phoneNo})
    }).then(res => res.json())
    .then(res => key.innerHTML = res.key)
    .catch((err) => console.log(err));
}