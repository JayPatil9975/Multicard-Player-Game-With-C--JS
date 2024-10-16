// Create a connection to the SignalR Hub
const connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

connection.start().catch(err => console.error(err.toString()));

// Function to send the user's move to the server
function playGame(userMove) {
    connection.invoke("PlayGame", userMove).catch(err => console.error(err.toString()));
}

// Function to receive and display the result
connection.on("ReceiveResult", (userMove, computerMove, result) => {
    document.getElementById("userMove").innerText = userMove;
    document.getElementById("computerMove").innerText = computerMove;
    document.getElementById("resultMessage").innerText = result;
});
