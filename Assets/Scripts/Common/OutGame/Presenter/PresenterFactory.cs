using System;
using System.Linq.Expressions;
using System.Reflection;
using Common.OutGame.View;

namespace Common.OutGame.Presenter
{
    public static class PresenterFactory<TPresenter, TView>
        where TPresenter : PresenterBase<TView> where TView : ViewBase
    {
        private static Func<PrefabGenParams, TPresenter> _delegateCache;

        public static TPresenter Create(PrefabGenParams genParams)
        {
            _delegateCache ??= CreateInstanceDelegate<TPresenter>();

            return _delegateCache(genParams);
        }

        private static Func<PrefabGenParams, TResult> CreateInstanceDelegate<TResult>()
        {
            var constructorInfo = typeof(TResult).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(PrefabGenParams)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(PrefabGenParams));

            return Expression.Lambda<Func<PrefabGenParams, TResult>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}