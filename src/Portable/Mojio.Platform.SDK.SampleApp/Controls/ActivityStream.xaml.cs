using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Mojio.Platform.SDK.SampleApp.Controls
{
    public sealed partial class ActivityStream : UserControl
    {
        public ActivityStream()
        {
            this.InitializeComponent();

            var vm = DIContainer.Current.Resolve<IActivityStreamViewModel>();

            this.DataContext = vm;

            vm.Init();
        }
    }
}