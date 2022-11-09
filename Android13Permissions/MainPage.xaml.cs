namespace Android13Permissions;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void TakePhotoButton_OnClicked(object sender, EventArgs e)
    {
        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await DisplayAlert("Error", "Capture not supported", "Ok");
                return;
            }

            try
            {
                await MediaPicker.Default.CapturePhotoAsync();
            }
            catch (Exception exception)
            {
                await DisplayAlert("Exception", exception.Message, "Ok");
            }
        });
    }
}

