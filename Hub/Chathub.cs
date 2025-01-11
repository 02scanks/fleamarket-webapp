using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

public class Chathub : Hub 
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task CreatePrivateGroup(string otherUserId)
    {
        // generate name
        var groupName = GenerateGroupName(Context.ConnectionId, otherUserId);

        // add the caller to the group
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        // notify the other user (if connected) to join the group
        await Clients.User(otherUserId).SendAsync("JoinGroup", groupName);
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }



    private string GenerateGroupName(string userId1, string userId2)
    {
        return userId1.CompareTo(userId2) < 0 ? $"{userId1}-{userId2}" : $"{userId2}-{userId1}";
    }
}