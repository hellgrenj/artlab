document.addEventListener("DOMContentLoaded", async function () {

    await RenderObservations();
    await AddEventListeners();

});

async function RenderObservations() {
    const observationsDiv = document.getElementById("observations");
    observationsDiv.innerHTML = ''
    var observations = await GetObservations();
    observations.forEach(ob => {
        observationsDiv.innerHTML += `An IT consultant with the description "${ob.description}" was observed in ${ob.city} (coordinates: ${ob.lat} ${ob.long} )<br/>`
    })
}
async function AddEventListeners() {
    const form = document.getElementById("createObservationForm");
    form.addEventListener("submit", async function (evt) {
        evt.preventDefault();
        const observation = { city: document.getElementById("city").value, description: document.getElementById("description").value }
        const result = await CreateObservation(observation)
        console.log(`result ${result.success}`)
        if(result.success) {
            RenderObservations();
        } else {
            alert(result.message)
        }
    });
}
async function GetObservations() {
    var response = await fetch("http://localhost:1337/observation");
    var observations = await response.json();
    console.log(observations)
    return observations;
}
async function CreateObservation(observation) {
    const response = await fetch('http://localhost:1337/observation', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(observation)
    });
    if (response.status === 200) {
        document.getElementById("city").value = ''
        document.getElementById("description").value = ''
        return { success: true, message: '' }
    } else {
        return { success: false, message: await response.json()}
    }
   
}