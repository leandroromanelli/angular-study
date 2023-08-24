﻿using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IRoomService : IService<Room>
    {
        Task<Room> AddRoom(string tenant, Room room, CancellationToken cancellationToken);
    }
}
