﻿using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class TypeDetail : BaseEntity<int> {
        public string? Name { get; set; }
        public Guid SectionId { get; set; }
        public virtual Section? Section { get; set; }
    }
}
