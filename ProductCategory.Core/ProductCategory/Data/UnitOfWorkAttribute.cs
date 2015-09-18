using System;

namespace ProductCategory.Core.ProductCategory.Data
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : Attribute
    {
    }
}