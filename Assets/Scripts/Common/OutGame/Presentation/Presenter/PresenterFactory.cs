using System;
using System.Linq.Expressions;
using System.Reflection;
using Common.OutGame.Presentation.View;

namespace Common.OutGame.Presentation.Presenter
{
    public static class PresenterFactory<TPresenter, TView>
        where TPresenter : PresenterBase<TView> where TView : ViewBase
    {
        private static Func<PrefabGenParams, TPresenter> _delegateCache;

        public static TPresenter Create(PrefabGenParams genParams)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(genParams);
        }

        private static Func<PrefabGenParams, TPresenter> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(TPresenter).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(PrefabGenParams)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(PrefabGenParams));

            return Expression.Lambda<Func<PrefabGenParams, TPresenter>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}