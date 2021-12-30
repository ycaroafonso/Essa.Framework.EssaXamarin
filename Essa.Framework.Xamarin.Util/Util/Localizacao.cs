namespace Essa.Framework.Util.Util
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xamarin.Essentials;


    /// <summary>
    /// https://docs.microsoft.com/pt-br/xamarin/essentials/geolocation?tabs=android
    /// </summary>
    public class Localizacao
    {
        CancellationTokenSource cts;

        public Location Location { get; private set; }

        async Task GetCurrentLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();

                Location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (Location != null)
                {
                    Console.WriteLine($"Latitude: {Location.Latitude}, Longitude: {Location.Longitude}, Altitude: {Location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        //protected override void OnDisappearing()
        public void Cancelar()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
        }
    }
}
