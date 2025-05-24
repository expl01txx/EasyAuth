using Grpc.Core;
using EasyAuth.Grpc;
using Google.Protobuf;
using System.Text;
using EasyAuth.Data;
using Microsoft.EntityFrameworkCore;
using EasyAuth.Models.Entities;
using Microsoft.AspNetCore.Hosting;

namespace EasyAuth.Services;

public class HyprSecService : HyprSec.HyprSecBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public HyprSecService(ApplicationDbContext dbContext, IWebHostEnvironment env)
    {
        _dbContext = dbContext;
        _env = env;
    }

    public override async Task<HyprSec_ImageReply> DownloadImage(HyprSec_AuthRequest request, ServerCallContext context)
    {
        var tokenModel = await _dbContext.Tokens
            .FirstOrDefaultAsync(t => t.Token == request.Token);

        if (tokenModel == null)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Not authorized"));
        }

        if (tokenModel.Expires < DateTime.UtcNow)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Not authorized"));
        }

        if (tokenModel.Hwid != null && tokenModel.Hwid != request.Hwid)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Not authorized"));
        }

        if (tokenModel.IsFreezed)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Not authorized"));
        }

        if (tokenModel.Role != "anticheat")
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Not authorized"));
        }


        if (tokenModel.Hwid == null && !string.IsNullOrEmpty(request.Hwid))
        {
            tokenModel.Hwid = request.Hwid;
            await _dbContext.SaveChangesAsync();
        }
        try
        {
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            var imagePath = Path.Combine(uploadsPath, "classes.rp2");

            if (!File.Exists(imagePath))
            {
                return new HyprSec_ImageReply
                {
                    Success = false,
                };
            }

            var imageBytes = File.ReadAllBytes(imagePath);
            return new HyprSec_ImageReply
            {
                Success = true,
                Image = ByteString.CopyFrom(imageBytes),
                Entry = ByteString.CopyFrom("f", Encoding.Unicode) //now unused
            };
        }
        catch (Exception)
        {
            return new HyprSec_ImageReply
            {
                Success = false,
            };
        }
    }
}