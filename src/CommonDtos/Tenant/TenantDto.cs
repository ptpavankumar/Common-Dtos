using System;

namespace CommonDtos.Tenant
{
    public class TenantDto
    {
        public Guid TenantId { get; set; }
        public Guid OrganisationId { get; set; }
    }
}
