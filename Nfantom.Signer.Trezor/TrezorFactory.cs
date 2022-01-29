using System.Linq;
using System.Threading.Tasks;
using Device.Net;
using Hid.Net;
using Trezor.Net;

namespace Nfantom.Signer.Trezor
{
    public class TrezorFactory
    {
        public static async Task<WindowsHidDevice> GetWindowsConnectedLedgerHidDeviceAsync()
        {
            var connectedDevices = WindowsHidDevice.GetConnectedDeviceInformations();

            var trezorDevices = connectedDevices.Where(d => TrezorManager.DeviceDefinitions.Any(a=>a.VendorId == d.VendorId) && TrezorManager.DeviceDefinitions.Any(a=>a.ProductId == 1)).ToList();
            var trezorDeviceInformation = trezorDevices.FirstOrDefault(t => TrezorManager.DeviceDefinitions.Any(a=>a.ProductId == t.ProductId));

            var trezorHidDevice = new WindowsHidDevice(trezorDeviceInformation);
            await trezorHidDevice.InitializeAsync().ConfigureAwait(false);
            return trezorHidDevice;
        }

        public static async Task<TrezorManager> GetWindowsConnectedLedgerManagerAsync(EnterPinArgs enterPinCallback)
        {
            var trezorHidDevice = await GetWindowsConnectedLedgerHidDeviceAsync().ConfigureAwait(false);
            return new TrezorManager(enterPinCallback, enterPinCallback, (IDevice)trezorHidDevice);
        }
    }
}
