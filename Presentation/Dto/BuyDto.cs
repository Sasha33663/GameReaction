﻿using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Dto;
public record BuyDto ( Guid userId, IEnumerable <BuyGameDto> buyGameDto);

