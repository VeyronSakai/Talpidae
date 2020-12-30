using System;
using OutGame.Common.Canvases;
using PrefabGenerator;
using UI.View.Title;
using UI.View.Title.Def;

namespace UI.Presenter.Title
{
    public class UITitleStaffCreditPresenter : IDisposable
    {
        public UITitleStaffCreditDialog StaffCreditDialog;

        public UITitleStaffCreditPresenter(AppCanvas canvas)
        {
            StaffCreditDialog =
                PrefabFactory.Create<UITitleStaffCreditDialog>(UITitleDef.UITitleStaffCreditDialog,
                    canvas.GetTransform());
        }

        public void Dispose()
        {
            PrefabDestroyer.Destroy(ref StaffCreditDialog);
        }
    }
}