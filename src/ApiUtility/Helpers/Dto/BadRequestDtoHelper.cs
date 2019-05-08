using System.Collections.Generic;
using ApiUtility.ActionFilter;
using ApiUtility.Extensions.String;
using CommonDtos.HttpResponse.BadRequest;
using CommonDtos.HttpResponse.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiUtility.Helpers.Dto
{
    public static class BadRequestDtoHelper
    {
        public static BadRequestResponseDto GetResponseDto(ModelStateDictionary modelState)
        {
            if (modelState.IsValid) return null;

            var badRequestResponseDetail = new List<ResponseDetail>();

            foreach (var errorState in modelState)
            {
                var detail = GetDetail(errorState);

                if (detail.Messages.Count > 0) badRequestResponseDetail.Add(detail);
            }

            return new BadRequestResponseDto
            {
                Type = BadRequestResponseUtility.Types.FieldValidation,
                Details = badRequestResponseDetail
            };
        }

        private static ResponseDetail GetDetail(KeyValuePair<string, ModelStateEntry> errorState)
        {
            var detail = new ResponseDetail
            {
                Name = errorState.Key.ToCamelCase(),
                Messages = new List<string>()
            };

            if (errorState.Value?.Errors == null) return detail;

            foreach (var error in errorState.Value.Errors) detail.Messages.Add(GetErrorFrom(error));

            return detail;
        }

        private static string GetErrorFrom(ModelError error)
        {
            if (error == null) return string.Empty;

            return string.IsNullOrWhiteSpace(error.ErrorMessage) ? Constants.InvalidDataType : error.ErrorMessage;
        }
    }
}