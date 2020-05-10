using AutoMapper;
using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.UseCases.Common;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateInvoice;
using Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetAllInvoices;
using Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Mappings
{
    internal class InvoicesMappingProfile : Profile
    {
        public InvoicesMappingProfile()
        {
            // Queries.
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Total, opt => opt.MapFrom(src => src.CalculateTotal()));

            CreateMap<InvoiceLineItem, InvoiceLineItemDto>()
                .ForMember(x => x.Total, opt => opt.MapFrom(src => src.CalculateTotal()));

            CreateMap<Product, LookupDto>();

            CreateMap<Invoice, InvoiceListDto>();

            // Commands.
            CreateMap<CreateInvoiceDto, Invoice>();

            CreateMap<CreateInvoiceLineItemDto, InvoiceLineItem>();

        }
    }
}
