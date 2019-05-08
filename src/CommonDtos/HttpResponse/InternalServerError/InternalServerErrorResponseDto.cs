using CommonDtos.HttpResponse.Common;

namespace CommonDtos.HttpResponse.InternalServerError
{
    public sealed class InternalServerErrorResponseDto : ResponseDto
    {
        public string CorrelationId { get; set; }
    }
}