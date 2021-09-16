const elementExist = (elementId) => {
    const el = document.getElementById(elementId)
    return el !== undefined && el !== null;
}
document.addEventListener("DOMContentLoaded", async function () {
    if (elementExist("observations")) {
        const observationsDiv = document.getElementById("observations");
        var observations = await GetObservations();
        observations.forEach(ob => {
            observationsDiv.innerHTML += `En IT-Konsult med beskrivningen "${ob.description}" observerades i ${ob.city} som har koordinaterna ${ob.lat} ${ob.long} <br/>`
        })
    } else {
        console.log("element observations does not exist right now..");
    }
});
async function GetObservations() {
    var response = await fetch("http://localhost:1337/observation");
    var observations = await response.json();
    console.log(observations)
    return observations;
}