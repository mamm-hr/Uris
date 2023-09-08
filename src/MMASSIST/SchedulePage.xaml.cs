using Microsoft.Maui.Animations;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MMASSIST;

internal class MyColumnItem
{
    public readonly int Index;
    public readonly DateOnly Date;
    public string Name => Date.ToShortDateString();

    public MyColumnItem(int index, DateOnly date)
    {
        Index = index;
        Date = date;
    }
}

internal class TimeRulerItem
{
    public readonly TimeOnly Time;

    public string Text => Time.ToShortTimeString();

    public TimeRulerItem(TimeOnly time)
    {
        Time = time;
    }
}

internal class ScheduleViewModel
{
    public ObservableCollection<MyColumnItem> Columns { get; private set; }
    public ObservableCollection<TimeRulerItem> TimeRulerItems { get; private set; }

    public ScheduleViewModel()
    {
        var columns = new List<MyColumnItem>();
        for(int i = 0; i < 7; i++ )
            columns.Add( new MyColumnItem( i, DateOnly.FromDateTime( DateTime.Now.AddDays(i) ) ) );
        this.Columns = new( columns );

        var timeRulerItems = new List<TimeRulerItem>();
        for(int i = 0; i < 24; i++)
            timeRulerItems.Add( new TimeRulerItem( new TimeOnly( 0, 0 ).AddHours( i ) ) );
        this.TimeRulerItems = new( timeRulerItems );
    }
}

public partial class SchedulePage : ContentPage
{
	public SchedulePage()
	{
		InitializeComponent();
	}


#if false
    private void PointerGestureRecognizer_PointerEntered( object sender, PointerEventArgs e )
    {
        Point? relPos = e.GetPosition(sender as View);
        m_pointerEntered.Text = $"{relPos.Value.X}@{relPos.Value.Y}";
    }

    private void PointerGestureRecognizer_PointerExited( object sender, PointerEventArgs e )
    {
        Point? relPos = e.GetPosition(sender as View);
        m_pointerExited.Text = $"{relPos.Value.X}@{relPos.Value.Y}";
    }

    private void PointerGestureRecognizer_PointerMoved( object sender, PointerEventArgs e )
    {
        Point? relPos = e.GetPosition(sender as View);
        m_pointerMoved.Text = $"{relPos.Value.X}@{relPos.Value.Y}";
    }

    private void TapGestureRecognizer_Tapped( object sender, TappedEventArgs e )
    {
        Point? relPos = e.GetPosition(sender as View);
        ButtonsMask buttons = e.Buttons;
        m_tappedPrimary.Text = 0 != (buttons & ButtonsMask.Primary) ? "Primary" : "";
        m_tappedSecondary.Text = 0 != (buttons & ButtonsMask.Secondary) ? "Secondary" : "";
        m_tappedPosition.Text = $"{relPos.Value.X}@{relPos.Value.Y}";
    }

    private void SwipeGestureRecognizer_Swiped( object sender, SwipedEventArgs e )
    {
        m_swipeDirection.Text =  $"{e.Direction}@{TimeOnly.FromDateTime( DateTime.Now ):HH:mm:ss}";
    }

    private void PanGestureRecognizer_PanUpdated( object sender, PanUpdatedEventArgs e )
    {
        m_panGestureId.Text = e.GestureId.ToString();
        m_panStatusType.Text = e.StatusType.ToString();
        m_panTotalChange.Text = $"{e.TotalX}@{e.TotalY}";
    }
#endif
}