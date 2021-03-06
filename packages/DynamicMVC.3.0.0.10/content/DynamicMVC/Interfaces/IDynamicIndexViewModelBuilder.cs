﻿using DynamicMVC.DynamicEntityMetadataLibrary.Models;
using DynamicMVC.UI.DynamicMVC.ViewModels;

namespace DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicIndexViewModelBuilder
    {
        DynamicIndexViewModel Build(DynamicEntityMetadata dynamicEntityMetadata);
    }
}