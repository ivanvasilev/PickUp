﻿using PickUp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUp.Services.Data.Contracts
{
    public interface IImagesService
    {
        void Create(Image image);
    }
}