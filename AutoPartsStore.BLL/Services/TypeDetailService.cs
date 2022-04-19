using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.BLL.Services {
    public class TypeDetailService : BaseService<TypeDetail, TypeDetailDTO, int, TypeDetailFilter> {
        public TypeDetailService(
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<BaseService<TypeDetail, TypeDetailDTO, int, TypeDetailFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<TypeDetail> Include(IQueryable<TypeDetail> query) {
            return query
                .Include(m => m.Section);
        }

        protected override IQueryable<TypeDetail> FilterOut(IQueryable<TypeDetail> query, TypeDetailFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (filter.SectionId != 0) {
                query = query.Where(m => m.SectionId == filter.SectionId);
            }
            return query;
        }

        protected override IQueryable<TypeDetail> OrderBy(IQueryable<TypeDetail> query, TypeDetailFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override TypeDetailFilter GetFilter(IFormCollection form) {
            TypeDetailFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(form["SectionId"]) && int.TryParse(form["SectionId"], out int result)) {
                filter.SectionId = result;
            }
            return filter;
        }
    }
}
