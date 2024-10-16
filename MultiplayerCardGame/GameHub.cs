using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class GameHub : Hub
{
    public async Task PlayGame(string userMove)
    {
        string[] choices = { "Rock", "Paper", "Scissors" };
        string computerMove = choices[new Random().Next(choices.Length)];

        string result = DetermineWinner(userMove, computerMove);
        await Clients.Caller.SendAsync("ReceiveResult", userMove, computerMove, result);
    }

    private string DetermineWinner(string userMove, string computerMove)
    {
        if (userMove == computerMove) return "It's a tie!";
        if ((userMove == "Rock" && computerMove == "Scissors") ||
            (userMove == "Paper" && computerMove == "Rock") ||
            (userMove == "Scissors" && computerMove == "Paper"))
        {
            return "You win!";
        }
        return "Computer wins!";
    }
}
