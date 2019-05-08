using System.Collections.Generic;

namespace CommonDtos.HttpResponse.Common
{
    public class ResponseDto
    {
        public string Type { get; set; }
        public List<ResponseDetail> Details { get; set; }
    }

    public class ResponseDetail
    {
        public string Name { get; set; }
        public List<string> Messages { get; set; }
    }
}