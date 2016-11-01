using Mojio.Platform.SDK.Contracts.ActivityStreams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Mojio.Platform.SDK.SampleApp.Contracts.ViewModels
{
    public interface IActivityStreamViewModel
    {
        Task Init();

        IList<IActivityViewModel> ActivityStream { get; set; }
    }

    public interface IActivityViewModel
    {
        ImageSource SummaryImage { get; set; }
        string PublishedDateTime { get; set; }
        string TextDescription { get; set; }

        System.Uri MapUrl { get; set; }
        Visibility HasMapLink { get; set; }

        string Duration { get; set; }
        Visibility HasDuration { get; set; }
        IActivity Source { get; set; }

        ImageSource VehicleImage { get; set; }

        string SummaryInitials { get; set; }

        System.Uri StaticMapLink { get; set; }
        Visibility StaticMapVisibility { get; set; }
    }
}