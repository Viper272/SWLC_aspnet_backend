using aspnet_backend.Contexts;
using aspnet_backend.Contexts.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace aspnet_backend.Endpoints
{
    public static class PlayerAuthEndpoints
    {
        public static void RegisterPlayerEndpoints(this WebApplication app)
        {
            var players = app.MapGroup("/players");

            players.MapGet("/", GetAllPlayers);
            players.MapGet("/{id}", GetPlayerByID);
            players.MapPost("/", PostPlayer);
        }

        static async Task<List<Player>> GetAllPlayers(PlayerDb db) =>
            await db.Players.ToListAsync();

        static async Task<Results<Ok<Player>, NotFound>> GetPlayerByID(int id, PlayerDb db) =>
            await db.Players.FindAsync(id)
                is Player player
                    ? TypedResults.Ok(player)
                    : TypedResults.NotFound();

        static async Task<Created<Player>> PostPlayer(Player player, PlayerDb db)
        {
            db.Players.Add(player);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/players/{player.Id}", player);
        }
    }
}


