﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Cargo.DtoLayer.Dtos.CargoOperationDtos
{
    public class CreateCargoOperationDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
