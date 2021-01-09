using System;
using System.Linq.Expressions;
using System.Reflection;
using Common.OutGame.Canvas;

namespace Common.OutGame.Presentation.Page
{
    public static class PageFactory<T> where T : IPage
    {
        private static Func<AppCanvasContainer, T> _delegateCache;

        public static T Create(AppCanvasContainer canvasContainer)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(canvasContainer);
        }

        private static Func<AppCanvasContainer, T> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(AppCanvasContainer)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(AppCanvasContainer));

            return Expression.Lambda<Func<AppCanvasContainer, T>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}