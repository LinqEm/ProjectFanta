function create() {
    document.getElementById('create').addEventListener('submit', create);
    const phoneNo = document.getElementById('phoneNo').value;
    const key = document.getElementById('key');

    event.preventDefault();

    fetch('/api/group', {
        method: 'POST',
        headers: {"content-type": "application/json"},
        body: JSON.stringify({phoneNumber: phoneNo})
    }).then(res => res.json())
    .then(res => key.innerHTML = res)
    .catch((err) => console.log(err));
}