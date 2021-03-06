﻿using MaplePacketLib2.Tools;
using MapleServer2.Constants;
using MapleServer2.Enums;
using MapleServer2.Servers.Game;
using MapleServer2.Tools;
using Microsoft.Extensions.Logging;

namespace MapleServer2.PacketHandlers.Game
{
    public class UserChatHandler : GamePacketHandler
    {
        public override RecvOp OpCode => RecvOp.USER_CHAT;

        public UserChatHandler(ILogger<GamePacketHandler> logger) : base(logger) { }

        public override void Handle(GameSession session, PacketReader packet)
        {
            ChatType type = (ChatType)packet.ReadInt();
            string message = packet.ReadUnicodeString();
            string recipient = packet.ReadUnicodeString();
            packet.ReadLong();

            GameCommandActions.Process(session, message);
            session.FieldManager.SendChat(session.Player, message, type);
        }
    }
}
// Party invite
// 01 09 00 42 00 75 00 62 00 62 00 6C 00 65 00 47 00 75 00 6E 00