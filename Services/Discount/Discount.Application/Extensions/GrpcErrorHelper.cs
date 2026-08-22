using GrpcCore = global::Grpc.Core;
using Google.Rpc;
using Google.Protobuf;

using GoogleStatus = Google.Rpc.Status;
using GrpcStatus = Grpc.Core.Status;

namespace Discount.Application.Extensions
{
    public class GrpcErrorHelper
    {
        public static GrpcCore.RpcException CreateValidationException(Dictionary<string, string> fieldErrors)
        {
            var fieldViolations = new List<BadRequest.Types.FieldViolation>();
            foreach (var error in fieldErrors)
            {
                fieldViolations.Add(new BadRequest.Types.FieldViolation
                {
                    Field = error.Key,
                    Description = error.Value
                });
            }

            var badRequest = new BadRequest();
            badRequest.FieldViolations.AddRange(fieldViolations);

            var status = new Google.Rpc.Status
            {
                Code = (int)GrpcCore.StatusCode.InvalidArgument,
                Message = "Validation Failed",
                Details = { Google.Protobuf.WellKnownTypes.Any.Pack(badRequest) } // C# collection initializer works when Details property is pre-instantiated
            };

            var trailers = new GrpcCore.Metadata
    {
        { "grpc-status-details-bin", status.ToByteArray() }
    };

            return new GrpcCore.RpcException(new GrpcCore.Status(GrpcCore.StatusCode.InvalidArgument, "Validation Errors"), trailers);
        }
    }
}
