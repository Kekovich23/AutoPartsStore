using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace AutoPartsStore.BLL.Services {
    public class SectionService : BaseService<Section, SectionDTO, int, SectionFilter> {
        public SectionService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Section, SectionDTO, int, SectionFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Section> FilterOut(IQueryable<Section> query, SectionFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower() == filter.Name.ToLower());
            }
            return query;
        }

        protected override IQueryable<Section> OrderBy(IQueryable<Section> query, SectionFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override SectionFilter GetFilter(IFormCollection form) {
            SectionFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}
