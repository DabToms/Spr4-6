﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;
internal class WarehouseProductRecord
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductionNumber { get; set; }
    public DateTime ProductionDate { get; set; }
    public int ProductionQuantity { get; set; }
    public int QuantityLeft { get; set; }
}
