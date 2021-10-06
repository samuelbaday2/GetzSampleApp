using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetzSampleApp.Utility
{
    public class Threader
    {
        public void QuickThread(Action block)
        {
            NewThread(block);
        }

        private async void NewThread(Action block)
        {
            await Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => {
                    block();
                });
            });
        }

        public async void ForkThread(Action block)
        {
            await Task.Run(() => { block(); });
        }
    }
}
