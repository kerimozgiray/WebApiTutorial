using System;
using System.Reflection;
using ProductCategory.Core.ProductCategory.Data;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace PrductCategory.Depedency.ProductCategory.Dependency.UoW
{
    public static class UnitOfWorkHelper
    {
        public static bool IsRepositoryMethod(MethodInfo methodInfo)
        {
            return IsRepositoryClass(methodInfo.DeclaringType);
        }

        public static bool IsRepositoryClass(Type declaringType)
        {
            return typeof (IRepository).IsAssignableFrom(declaringType);
        }

        public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof (UnitOfWorkAttribute), true);
        }
    }
}