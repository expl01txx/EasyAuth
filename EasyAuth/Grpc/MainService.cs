using Grpc.Core;
using EasyAuth.Grpc;
using Google.Protobuf;
using System.Text;

namespace EasyAuth.Services;

public class HyprSecService : HyprSec.HyprSecBase
{
    public override Task<HyprSec_ImageReply> DownloadImage(HyprSec_AuthRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HyprSec_ImageReply
        {
            Success = true,
            Image = ByteString.CopyFromUtf8("Hello"),
            Entry = ByteString.CopyFromUtf8("World")
        });
    }
}